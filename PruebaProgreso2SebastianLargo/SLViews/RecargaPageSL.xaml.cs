namespace PruebaProgreso2SebastianLargo.SLViews;

public partial class RecargaPageSL : ContentPage
{
    private const string FileName = "SebastianLargo.txt";

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

        var recarga = new SLModels.RecargaSL
        {
            Nombre = nombre,
            NumeroTelefono = numero
        };

        File.WriteAllText(FileName, recarga.ToString());

        SL_Label3.Text = "¡Recarga exitosa!";
        SL_Label3.TextColor = Colors.Green;

        CargarUltimaRecarga();

        SL_Entry1.Text = string.Empty;
        SL_Entry2.Text = string.Empty;
    }

    private void CargarUltimaRecarga()
    {
        if (File.Exists(FileName))
        {
            SL_Label5.Text = File.ReadAllText(FileName);
        }
        else
        {
            SL_Label5.Text = "No hay recargas registradas.";
        }
    }
}