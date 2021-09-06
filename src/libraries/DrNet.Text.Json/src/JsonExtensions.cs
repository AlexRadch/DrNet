// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

namespace System.Text.Json
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
        public static string TryGetPropertyString(this JsonElement element, string propertyName)
        {
            if (element.ValueKind == JsonValueKind.Object && element.TryGetProperty(propertyName, out var property))
            {
                switch (property.ValueKind)
                {
                    case JsonValueKind.String:
                    case JsonValueKind.Number:
                    case JsonValueKind.True:
                    case JsonValueKind.False:
                        return property.GetString().Trim();
                }
            }

            return default;
        }


    }
}
