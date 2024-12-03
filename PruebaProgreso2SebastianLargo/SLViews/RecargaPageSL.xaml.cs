namespace PruebaProgreso2SebastianLargo.SLViews;

public partial class RecargaPageSL : ContentPage
{
    private readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "SebastianLargo.txt");

    public RecargaPageSL()
    {
        InitializeComponent();
        CargarUltimaRecarga();
    }

    private void OnRecargarClicked(object sender, EventArgs e)
    {
        string numero = SL_Entry1.Text;
        string nombre = SL_Entry2.Text;

        if (string.IsNullOrEmpty(numero) || string.IsNullOrEmpty(nombre))
        {
            SL_Label3.Text = "Por favor, complete todos los campos.";
            SL_Label3.TextColor = Colors.Red;
            return;
        }

        // Crear una instancia del modelo Recarga
        var recarga = new SLModels.RecargaSL
        {
            Nombre = nombre,
            NumeroTelefono = numero
        };

        // Guardar la información en el archivo
        File.WriteAllText(FilePath, recarga.ToString());

        // Mostrar mensaje de éxito
        SL_Label3.Text = "¡Recarga exitosa!";
        SL_Label3.TextColor = Colors.Green;

        // Recargar la última recarga
        CargarUltimaRecarga();

        // Limpiar formulario
        SL_Entry1.Text = string.Empty;
        SL_Entry2.Text = string.Empty;
    }

    private void CargarUltimaRecarga()
    {
        if (File.Exists(FilePath))
        {
            SL_Label5.Text = File.ReadAllText(FilePath);
        }
        else
        {
            SL_Label5.Text = "No hay recargas registradas.";
        }
    }

}