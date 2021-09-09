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

        public static string? TryGetString(this JsonElement element)
        => element.ValueKind.InSet(JsonValueKind.String, JsonValueKind.Number, JsonValueKind.True, JsonValueKind.False) ? element.GetString() : default;

        public static bool? TryGetBoolean(this JsonElement element)
        => element.ValueKind switch
        {
            JsonValueKind.False => false,
            JsonValueKind.True => true,
            _ => default,
        };

        public static byte? TryGetByte(this JsonElement element)
        => element.ValueKind == JsonValueKind.Number && element.TryGetByte(out byte value) ? value : default;

        public static byte[]? TryGetBytesFromBase64(this JsonElement element)
        => element.ValueKind == JsonValueKind.String && element.TryGetBytesFromBase64(out byte[]? value) ? value : default;

        public static DateTime? TryGetDateTime(this JsonElement element)
        => element.ValueKind == JsonValueKind.String && element.TryGetDateTime(out DateTime value) ? value : default;

        public static DateTimeOffset? TryGetDateTimeOffset(this JsonElement element)
        => element.ValueKind == JsonValueKind.String && element.TryGetDateTimeOffset(out DateTimeOffset value) ? value : default;

        public static decimal? TryGetDecimal(this JsonElement element)
        => element.ValueKind == JsonValueKind.Number && element.TryGetDecimal(out decimal value) ? value : default;

        public static double? TryGetDouble(this JsonElement element)
        => element.ValueKind == JsonValueKind.Number && element.TryGetDouble(out double value) ? value : default;

        public static Guid? TryGetGuid(this JsonElement element)
        => element.ValueKind == JsonValueKind.String && element.TryGetGuid(out Guid value) ? value : default;

        public static short? TryGetInt16(this JsonElement element)
        => element.ValueKind == JsonValueKind.Number && element.TryGetInt16(out short value) ? value : default;

        public static int? TryGetInt32(this JsonElement element)
        => element.ValueKind == JsonValueKind.Number && element.TryGetInt32(out int value) ? value : default;

        public static long? TryGetInt64(this JsonElement element)
        => element.ValueKind == JsonValueKind.Number && element.TryGetInt64(out long value) ? value : default;

        public static JsonElement? TryGetElement(this JsonElement element, ReadOnlySpan<byte> utf8PropertyName)
        => element.ValueKind == JsonValueKind.Object && element.TryGetProperty(utf8PropertyName, out JsonElement property) ? property : default;

        public static JsonElement? TryGetElement(this JsonElement element, ReadOnlySpan<char> propertyName)
        => element.ValueKind == JsonValueKind.Object && element.TryGetProperty(propertyName, out JsonElement property) ? property : default;

        public static JsonElement? TryGetElement(this JsonElement element, string propertyName)
        => element.ValueKind == JsonValueKind.Object && element.TryGetProperty(propertyName, out JsonElement property) ? property : default;

        public static sbyte? TryGetSByte(this JsonElement element)
        => element.ValueKind == JsonValueKind.Number && element.TryGetSByte(out sbyte property) ? property : default;

        public static float? TryGetSingle(this JsonElement element)
        => element.ValueKind == JsonValueKind.Number && element.TryGetSingle(out float property) ? property : default;

        public static ushort? TryGetUInt16(this JsonElement element)
        => element.ValueKind == JsonValueKind.Number && element.TryGetUInt16(out ushort property) ? property : default;

        public static uint? TryGetUInt32(this JsonElement element)
        => element.ValueKind == JsonValueKind.Number && element.TryGetUInt32(out uint property) ? property : default;

        public static ulong? TryGetUInt64(this JsonElement element)
        => element.ValueKind == JsonValueKind.Number && element.TryGetUInt64(out ulong property) ? property : default;

        #endregion

        #region TryGetPropertyType

        public static string? TryGetPropertyString(this JsonElement element, string propertyName)
        => element.TryGetElement(propertyName)?.TryGetString();

        public static string? TryGetPropertiesString(this JsonElement element, IEnumerable<string> propertyNames)
        => element.ValueKind == JsonValueKind.Object
            ? propertyNames.Select(propertyName => element.TryGetPropertyString(propertyName)).FirstOrDefault(value => !value.IsNullOrEmpty())
            : default;

        public static string? TryGetPropertiesString(this JsonElement element, params string[] propertyNames)
        => element.TryGetPropertiesString((IEnumerable<string>)propertyNames);

        public static bool? TryGetPropertyBoolean(this JsonElement element, string propertyName)
        => element.TryGetElement(propertyName)?.TryGetBoolean();

        public static byte? TryGetPropertyByte(this JsonElement element, string propertyName)
        => element.TryGetElement(propertyName)?.TryGetByte();

        public static byte[]? TryGetPropertyBytesFromBase64(this JsonElement element, string propertyName)
        => element.TryGetElement(propertyName)?.TryGetBytesFromBase64();

        public static DateTime? TryGetPropertyDateTime(this JsonElement element, string propertyName)
        => element.TryGetElement(propertyName)?.TryGetDateTime();

        public static DateTimeOffset? TryGetPropertyDateTimeOffset(this JsonElement element, string propertyName)
        => element.TryGetElement(propertyName)?.TryGetDateTimeOffset();

        public static decimal? TryGetPropertyDecimal(this JsonElement element, string propertyName)
        => element.TryGetElement(propertyName)?.TryGetDecimal();

        public static double? TryGetPropertyDouble(this JsonElement element, string propertyName)
        => element.TryGetElement(propertyName)?.TryGetDouble();

        public static Guid? TryGetPropertyGuid(this JsonElement element, string propertyName)
        => element.TryGetElement(propertyName)?.TryGetGuid();

        public static short? TryGetPropertyInt16(this JsonElement element, string propertyName)
        => element.TryGetElement(propertyName)?.TryGetInt16();

        public static int? TryGetPropertyInt32(this JsonElement element, string propertyName)
        => element.TryGetElement(propertyName)?.TryGetInt32();

        public static long? TryGetPropertyInt64(this JsonElement element, string propertyName)
        => element.TryGetElement(propertyName)?.TryGetInt64();

        public static sbyte? TryGetPropertySByte(this JsonElement element, string propertyName)
        => element.TryGetElement(propertyName)?.TryGetSByte();

        public static float? TryGetPropertySingle(this JsonElement element, string propertyName)
        => element.TryGetElement(propertyName)?.TryGetSingle();

        public static ushort? TryGetPropertyUInt16(this JsonElement element, string propertyName)
        => element.TryGetElement(propertyName)?.TryGetUInt16();

        public static uint? TryGetPropertyUInt32(this JsonElement element, string propertyName)
        => element.TryGetElement(propertyName)?.TryGetUInt32();

        public static ulong? TryGetPropertyUInt64(this JsonElement element, string propertyName)
        => element.TryGetElement(propertyName)?.TryGetUInt64();

        #endregion
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
