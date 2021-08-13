namespace VisaForm.Devices
{
    public interface IDevice<T>
    {
        void Config(ConfigDevice cfg);
        void SendCommandToPort();
        void ResieveMessageFromComPort(out string message);

    }
}