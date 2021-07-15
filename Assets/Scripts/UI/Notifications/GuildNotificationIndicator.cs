public class GuildNotificationIndicator : NotificationIndicator
{
    private void OnEnable()
    {
        EventLog.NotifyUnreadMessages += SetVisible;
    }

    private void OnDisable()
    {
        EventLog.NotifyUnreadMessages -= SetVisible;
    }
}
