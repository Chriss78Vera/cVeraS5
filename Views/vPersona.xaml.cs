using cVeraS5.Models;
namespace cVeraS5.Views;
public partial class vPersona : ContentPage
{
    public vPersona() { InitializeComponent(); }
    protected override void OnAppearing() { base.OnAppearing(); RefrescarDirectorio(); }
    private void btnAgregar_Clicked(object? sender, EventArgs e) { var nombre = txtNombre.Text?.Trim(); if (string.IsNullOrWhiteSpace(nombre)) { lblMessage.Text = "Escribe un nombre antes de guardar."; return; } App._personRepo.AddNewPerson(nombre); lblMessage.Text = $"{nombre} fue agregado al directorio."; txtNombre.Text = string.Empty; RefrescarDirectorio(); }
    private void btnMostrar_Clicked(object? sender, EventArgs e) => RefrescarDirectorio();
    private void btnEliminar_Clicked(object? sender, EventArgs e) { if (sender is Button button && button.CommandParameter is int id) { App._personRepo.DeletePerson(id); lblMessage.Text = "Registro eliminado correctamente."; RefrescarDirectorio(); } }
    private void RefrescarDirectorio() { List<Persona> people = App._personRepo.GetAllPerson(); listaPersonas.ItemsSource = people; lblCount.Text = people.Count == 0 ? "Aún no hay registros" : $"{people.Count} {(people.Count == 1 ? "persona registrada" : "personas registradas")}"; }
}
