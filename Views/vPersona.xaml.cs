using VFloresS5_2.Modelos;


namespace VFloresS5_2.Views;

public partial class vPersona : ContentPage
{
    int idGlobal = 0;
    public vPersona()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";

        App.PersonRepo.AddNewPersona(txtNombre.Text);
        lblStatusMessage.Text = App.PersonRepo.StatusMessage;

    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {

        lblStatusMessage.Text = "";

        List<Persona> personas = App.PersonRepo.GetAllPeople();
        listPersonas.ItemsSource = personas;
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        if (idGlobal != 0)
        {
            lblStatusMessage.Text = "";

            App.PersonRepo.DeletePersona(idGlobal);
            lblStatusMessage.Text = App.PersonRepo.StatusMessage;
            txtNombreActualizado.Text = "";
            txtNombreEliminar.Text = "";
            idGlobal = 0;
            DisplayAlert("Alerta", "Registro eliminado correctamente!", "Cerrar");
        }
        else
        {
            DisplayAlert("Alerta Validación", "Debe seleccionar un nombre!", "Cerrar");
        }
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        if (idGlobal != 0)
        {
            lblStatusMessage.Text = "";

            App.PersonRepo.UpdatePersona(idGlobal, txtNombreActualizado.Text);
            lblStatusMessage.Text = App.PersonRepo.StatusMessage;
            txtNombreActualizado.Text = "";
            txtNombreEliminar.Text = "";
            idGlobal = 0;
            DisplayAlert("Alerta", "Registro actualizado correctamente!", "Cerrar");
        }
        else
        {
            DisplayAlert("Alerta Validación", "Debe seleccionar un nombre!", "Cerrar");
        }

    }

    private void listPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string nombreseleccionado = (e.CurrentSelection.FirstOrDefault() as Persona)?.Name;
        int idseleccionado = (int)((e.CurrentSelection.FirstOrDefault() as Persona)?.Id);
        idGlobal = idseleccionado;
        txtNombreActualizado.Text = nombreseleccionado;
        txtNombreEliminar.Text = nombreseleccionado;

    }
}