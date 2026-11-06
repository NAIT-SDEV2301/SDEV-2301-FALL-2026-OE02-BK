namespace Sdev2301.BlazorIntro_Services.Services
{
    public class SingletonMarker
    {
        public Guid InstanceId { get; } = Guid.NewGuid();
    }
}
