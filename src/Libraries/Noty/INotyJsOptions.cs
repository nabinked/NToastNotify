namespace NToastNotify.Libraries
{
    /// <summary>
    /// Mirrors the options object used by noty.js
    /// </summary>
    public interface INotyJsOptions
    {
        string[] CloseWith { get; set; }
        string Container { get; set; }
        bool? Force { get; set; }
        string Id { get; set; }
        string Layout { get; set; }
        bool? Modal { get; set; }
        bool? ProgressBar { get; set; }
        string Queue { get; set; }
        string Text { get; set; }
        string Theme { get; set; }
        int? Timeout { get; set; }
        Enums.NotificationTypesNoty Type { get; set; }
        bool? VisibilityControl { get; set; }
    }
}