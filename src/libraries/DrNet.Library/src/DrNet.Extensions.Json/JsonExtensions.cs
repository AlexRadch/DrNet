// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using DrNet.Extensions.String;
using System;
using System.Text.Json;

namespace DrNet.Extensions.Json
{
    /// <summary>
    /// Extensions for Json classes <see cref="JsonDocument"/>, <see cref="JsonElement"/>
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// TODO: TryGetProperty
        /// </summary>
        /// <param name="element"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static JsonElement? TryGetProperty(this JsonElement element, string propertyName)
        {
            if (element.ValueKind == JsonValueKind.Object && element.TryGetProperty(propertyName, out JsonElement property))
                return property;
            return default;
        }

        /// <summary>
        /// TODO: TryGetProperty
        /// </summary>
        /// <param name="element"></param>
        /// <param name="utf8PropertyName"></param>
        /// <returns></returns>
        public static JsonElement? TryGetProperty(this JsonElement element, ReadOnlySpan<byte> utf8PropertyName)
        {
            if (element.ValueKind == JsonValueKind.Object && element.TryGetProperty(utf8PropertyName, out JsonElement property))
                return property;
            return default;
        }

        /// <summary>
        /// TODO: TryGetProperty
        /// </summary>
        /// <param name="element"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static JsonElement? TryGetProperty(this JsonElement element, ReadOnlySpan<char> propertyName)
        {
            if (element.ValueKind == JsonValueKind.Object && element.TryGetProperty(propertyName, out JsonElement property))
                return property;
            return default;
        }

        /// <summary>
        /// TODO: TryGetPropertyString
        /// </summary>
        /// <param name="element"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static string? TryGetPropertyString(this JsonElement element, string propertyName)
        {
            if (element.ValueKind == JsonValueKind.Object && element.TryGetProperty(propertyName, out JsonElement property))
            {
                switch (property.ValueKind)
                {
                    case JsonValueKind.String:
                    case JsonValueKind.Number:
                    case JsonValueKind.True:
                    case JsonValueKind.False:
                        return property.GetString();
                }
            }

            return default;
        }

        /// <summary>
        /// TODO: TryGetPropertiesString
        /// </summary>
        /// <param name="element"></param>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        public static string? TryGetPropertiesString(this JsonElement element, params string[] propertyNames)
        {
            if (element.ValueKind == JsonValueKind.Object)
                foreach (string propertyName in propertyNames)
                {
                    string? result = element.TryGetPropertyString(propertyName);
                    if (!result.IsNullOrEmpty())
                        return result;
                }

            return default;
        }
    }
}
