namespace EmprestimosWall.Models
{
    public class ResponseModel<T>
    {
        private T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool status { get; set; } = true;
    }
}
