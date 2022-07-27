namespace APICatalogo.Services
{
    public class MeuServico : IMeuServico
    {

        public string Message(string nome)
        {
            return $"Bem vindo {nome} \n\n{DateTime.Now}";
        }

        public string TestaMessage(string message)
        {
            return $"Funciona na MeuServico e no contrato da Interface {message}";
        }
    }
}
