// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using DrNet.Extensions.Cs;
using DrNet.Extensions.String;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace DrNet.Extensions.Json
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Extensions for Json classes <see cref="JsonDocument"/>, <see cref="JsonElement"/>
    /// </summary>
    public static class JsonExtensions
    {
        #region TryGet

        public static JsonElement? TryGetPropertyOrNull(this JsonElement element, ReadOnlySpan<byte> utf8PropertyName)
        => element.ValueKind == JsonValueKind.Object && element.TryGetProperty(utf8PropertyName, out JsonElement property) ? property : null;

        public static JsonElement? TryGetPropertyOrNull(this JsonElement element, ReadOnlySpan<char> propertyName)
        => element.ValueKind == JsonValueKind.Object && element.TryGetProperty(propertyName, out JsonElement property) ? property : null;

        public static JsonElement? TryGetPropertyOrNull(this JsonElement element, string propertyName)
        => element.ValueKind == JsonValueKind.Object && element.TryGetProperty(propertyName, out JsonElement property) ? property : null;

        public static JsonElement? TryGetNestedPropertyOrNull(this JsonElement element, params string[] propertiesNames)
        //=> propertiesNames.Aggregate((JsonElement?)element, (element, propertyName) => element?.TryGetPropertyOrNull(propertyName));
        //{
        //    JsonElement? cElement = element;
        //    propertiesNames.TakeWhile(propertyName => { cElement = cElement.Value.TryGetPropertyOrNull(propertyName); return cElement.HasValue; }).Last();
        //    return cElement;
        //}
        {
            JsonElement? cElement = element;
            foreach (string? propertyName in propertiesNames)
            {
                cElement = cElement.Value.TryGetPropertyOrNull(propertyName);
                if (!cElement.HasValue)
                    break;
            }
            return cElement;
        }

        public static string? TryGetString(this JsonElement element)
        => element.ValueKind.InSet(JsonValueKind.String, JsonValueKind.Number, JsonValueKind.True, JsonValueKind.False, JsonValueKind.Null)
            ? element.ToString()
            : null;

        public static bool? TryGetBoolean(this JsonElement element)
        => element.ValueKind switch
        {
            JsonValueKind.False => false,
            JsonValueKind.True => true,
            _ => null,
        };

        public static byte? TryGetByte(this JsonElement element)
        => element.ValueKind == JsonValueKind.Number && element.TryGetByte(out byte value) ? value : null;

        public static byte[]? TryGetBytesFromBase64(this JsonElement element)
        => element.ValueKind == JsonValueKind.String && element.TryGetBytesFromBase64(out byte[]? value) ? value : null;

        public static DateTime? TryGetDateTime(this JsonElement element)
        => element.ValueKind == JsonValueKind.String && element.TryGetDateTime(out DateTime value) ? value : null;

        public static DateTimeOffset? TryGetDateTimeOffset(this JsonElement element)
        => element.ValueKind == JsonValueKind.String && element.TryGetDateTimeOffset(out DateTimeOffset value) ? value : null;

        public static decimal? TryGetDecimal(this JsonElement element)
        => element.ValueKind == JsonValueKind.Number && element.TryGetDecimal(out decimal value) ? value : null;

        public static double? TryGetDouble(this JsonElement element)
        => element.ValueKind == JsonValueKind.Number && element.TryGetDouble(out double value) ? value : default;

        public static Guid? TryGetGuid(this JsonElement element)
        => element.ValueKind == JsonValueKind.String && element.TryGetGuid(out Guid value) ? value : null;

        public static short? TryGetInt16(this JsonElement element)
        => element.ValueKind == JsonValueKind.Number && element.TryGetInt16(out short value) ? value : null;

        public static int? TryGetInt32(this JsonElement element)
        => element.ValueKind == JsonValueKind.Number && element.TryGetInt32(out int value) ? value : null;

        public static long? TryGetInt64(this JsonElement element)
        => element.ValueKind == JsonValueKind.Number && element.TryGetInt64(out long value) ? value : null;

        public static sbyte? TryGetSByte(this JsonElement element)
        => element.ValueKind == JsonValueKind.Number && element.TryGetSByte(out sbyte property) ? property : null;

        public static float? TryGetSingle(this JsonElement element)
        => element.ValueKind == JsonValueKind.Number && element.TryGetSingle(out float property) ? property : null;

        public static ushort? TryGetUInt16(this JsonElement element)
        => element.ValueKind == JsonValueKind.Number && element.TryGetUInt16(out ushort property) ? property : null;

        public static uint? TryGetUInt32(this JsonElement element)
        => element.ValueKind == JsonValueKind.Number && element.TryGetUInt32(out uint property) ? property : null;

        public static ulong? TryGetUInt64(this JsonElement element)
        => element.ValueKind == JsonValueKind.Number && element.TryGetUInt64(out ulong property) ? property : null;

        #endregion

        #region TryGetPropertyType

        public static string? TryGetPropertyString(this JsonElement element, string propertyName)
        => element.TryGetPropertyOrNull(propertyName)?.TryGetString();

        public static string? TryGetPropertiesString(this JsonElement element, IEnumerable<string> propertyNames)
        => element.ValueKind == JsonValueKind.Object
            ? propertyNames.Select(propertyName => element.TryGetPropertyString(propertyName)).FirstOrDefault(value => !value.IsNullOrEmpty())
            : null;

        public static string? TryGetPropertiesString(this JsonElement element, params string[] propertyNames)
        => element.TryGetPropertiesString((IEnumerable<string>)propertyNames);

        public static bool? TryGetPropertyBoolean(this JsonElement element, string propertyName)
        => element.TryGetPropertyOrNull(propertyName)?.TryGetBoolean();

        public static byte? TryGetPropertyByte(this JsonElement element, string propertyName)
        => element.TryGetPropertyOrNull(propertyName)?.TryGetByte();

        public static byte[]? TryGetPropertyBytesFromBase64(this JsonElement element, string propertyName)
        => element.TryGetPropertyOrNull(propertyName)?.TryGetBytesFromBase64();

        public static DateTime? TryGetPropertyDateTime(this JsonElement element, string propertyName)
        => element.TryGetPropertyOrNull(propertyName)?.TryGetDateTime();

        public static DateTimeOffset? TryGetPropertyDateTimeOffset(this JsonElement element, string propertyName)
        => element.TryGetPropertyOrNull(propertyName)?.TryGetDateTimeOffset();

        public static decimal? TryGetPropertyDecimal(this JsonElement element, string propertyName)
        => element.TryGetPropertyOrNull(propertyName)?.TryGetDecimal();

        public static double? TryGetPropertyDouble(this JsonElement element, string propertyName)
        => element.TryGetPropertyOrNull(propertyName)?.TryGetDouble();

        public static Guid? TryGetPropertyGuid(this JsonElement element, string propertyName)
        => element.TryGetPropertyOrNull(propertyName)?.TryGetGuid();

        public static short? TryGetPropertyInt16(this JsonElement element, string propertyName)
        => element.TryGetPropertyOrNull(propertyName)?.TryGetInt16();

        public static int? TryGetPropertyInt32(this JsonElement element, string propertyName)
        => element.TryGetPropertyOrNull(propertyName)?.TryGetInt32();

        public static long? TryGetPropertyInt64(this JsonElement element, string propertyName)
        => element.TryGetPropertyOrNull(propertyName)?.TryGetInt64();

        public static sbyte? TryGetPropertySByte(this JsonElement element, string propertyName)
        => element.TryGetPropertyOrNull(propertyName)?.TryGetSByte();

        public static float? TryGetPropertySingle(this JsonElement element, string propertyName)
        => element.TryGetPropertyOrNull(propertyName)?.TryGetSingle();

        public static ushort? TryGetPropertyUInt16(this JsonElement element, string propertyName)
        => element.TryGetPropertyOrNull(propertyName)?.TryGetUInt16();

        public static uint? TryGetPropertyUInt32(this JsonElement element, string propertyName)
        => element.TryGetPropertyOrNull(propertyName)?.TryGetUInt32();

        public static ulong? TryGetPropertyUInt64(this JsonElement element, string propertyName)
        => element.TryGetPropertyOrNull(propertyName)?.TryGetUInt64();

        #endregion
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
