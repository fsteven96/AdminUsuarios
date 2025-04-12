namespace AdminUsuariosApi.Models
{
    public class Departamento {
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public bool Activo { get; set; }
    public int IdUsuarioCreacion { get; set; }
}

}