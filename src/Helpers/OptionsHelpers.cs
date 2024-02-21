using System;
using static NToastNotify.Enums;

namespace NToastNotify.Helpers
{
    internal class OptionsHelpers
    {
        public static T CastOptionTo<T>(LibraryOptions? options) where T : LibraryOptions, new()
        {
            EnsureSameType<T>(options);
            var opt = options as T ?? new T();
            return opt;
        }
        public static void EnsureSameType<T>(object? obj) where T : new()
        {
            if (obj != null)
            {
                if (typeof(T) != obj.GetType())
                {
                    throw new InvalidCastException($"Wrong options type passed. Make sure you are passing the right toast options types. Passed options type {obj.GetType().Name}. Expected options type {typeof(T).Name}");
                }
            }
        }
        public static NotyOptions PrepareOptionsNoty(LibraryOptions? options, NotificationTypesNoty type)
        {
            var notyOptions = CastOptionTo<NotyOptions>(options);
            notyOptions.Type = type;
            return notyOptions;
        }
        public static ToastrOptions PrepareOptionsToastr(LibraryOptions? toastrOptions, NotificationTypesToastr type, string defaultTitle)
        {
            var options = CastOptionTo<ToastrOptions>(toastrOptions);
            options.Type = type;
            options.Title ??= defaultTitle;
            return options;
        }
        public static BootstrapOptions PrepareOptionsBootstrap(LibraryOptions? bootstrapOptions, NotificationTypesBootstrap type)
        {
            var options = CastOptionTo<BootstrapOptions>(bootstrapOptions);
            options.Type = type;
            return options;
        }
    }
}
