namespace ChamadoX.Models

    //*  Basicamente são clases que fazem a conexão com o banco de dados.
    // tabelas em forma de classe, tem como objetivo interligar o codigo ao banco de dados.

    
    
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
