namespace ftibantaS5.Views;

public partial class vPersona : ContentPage
{
    // Persona seleccionada en la lista
    private Models.Persona? personaSeleccionada;

	public vPersona()
	{
		InitializeComponent();
	}

    private void btnMostar_Clicked(object sender, EventArgs e)
    {
        CargarPersonas();
    }

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";
        App._personRepo.AddNewPerson(txtName.Text);
        lblStatusMessage.Text = App._personRepo.StatusMessage;
    }

    // Se ejecuta cuando el usuario selecciona un registro de la lista
    private void listaPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        personaSeleccionada = e.CurrentSelection.FirstOrDefault() as Models.Persona;
        btnEliminar.IsEnabled = personaSeleccionada is not null;
    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        if (personaSeleccionada is null)
            return;

        bool confirmar = await DisplayAlertAsync("Eliminar",
            $"¿Desea eliminar a {personaSeleccionada.Name}?", "Si", "No");

        if (!confirmar)
            return;

        lblStatusMessage.Text = "";
        App._personRepo.DeletePerson(personaSeleccionada.Id);
        lblStatusMessage.Text = App._personRepo.StatusMessage;

        CargarPersonas();
    }

    // Recarga la lista y limpia la seleccion
    private void CargarPersonas()
    {
        List<Models.Persona> people = App._personRepo.GetAllPerson();
        listaPersonas.ItemsSource = people;
        listaPersonas.SelectedItem = null;
        personaSeleccionada = null;
        btnEliminar.IsEnabled = false;
    }
}