namespace VisaForm.Devices
{
    public class CommandImplicits//для получения инденифиаторов кнопки и команды 
    {
        public string Command;
        public string Btn;

        public CommandImplicits(string command, string btnName)
        {
            Command = command;
            Btn = btnName;
        }

        public static implicit operator CommandImplicits(string command)
        {
            CommandImplicits c = new CommandImplicits(command, null);
            return c;
        }
    }
}