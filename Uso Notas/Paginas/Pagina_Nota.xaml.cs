namespace Uso_Notas.Paginas;

public partial class Pagina_Nota : ContentPage
{
	public Pagina_Nota()
	{
		InitializeComponent();
        BindingContext = new Modelo.Datos();
    }

    protected override void OnAppearing()
    {
        ((Modelo.Datos)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Pagina_Nota));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Modelo.Nota)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(Pagina_Nota)}?{nameof(Pagina_Nota.ItemId)}={note.Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }
}