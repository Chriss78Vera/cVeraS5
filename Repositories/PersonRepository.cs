using cVeraS5.Models;
using SQLite;

namespace cVeraS5.Repositories;

public class PersonRepository
{
    private readonly string _dbPath;
    private SQLiteConnection? _conn;
    public string Message { get; private set; } = string.Empty;
    public PersonRepository(string path) => _dbPath = path;
    private void Init()
    {
        if (_conn is not null) return;
        _conn = new SQLiteConnection(_dbPath);
        _conn.CreateTable<Persona>();
    }
    public void AddNewPerson(string name)
    {
        try
        {
            Init();
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("El nombre es requerido");
            _conn!.Insert(new Persona { Name = name.Trim() });
            Message = "Persona guardada";
        }
        catch (Exception ex) { Message = "Error: " + ex.Message; }
    }
    public List<Persona> GetAllPerson()
    {
        try { Init(); return _conn!.Table<Persona>().ToList(); }
        catch (Exception ex) { Message = "Error: " + ex.Message; return new List<Persona>(); }
    }
    public void DeletePerson(int id)
    {
        try { Init(); _conn!.Delete<Persona>(id); Message = "Persona eliminada"; }
        catch (Exception ex) { Message = "Error: " + ex.Message; }
    }

    public void UpdatePerson(int id, string name)
    {
        try
        {
            Init();
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("El nombre es requerido");
            var person = _conn!.Find<Persona>(id);
            if (person is null) throw new InvalidOperationException("No se encontró el contacto");
            person.Name = name.Trim();
            _conn.Update(person);
            Message = "Nombre actualizado";
        }
        catch (Exception ex) { Message = "Error: " + ex.Message; }
    }
}
