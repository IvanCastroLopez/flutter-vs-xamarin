using System;
using Xamarin.Forms;
using ZenNotes.Models;

namespace ZenNotes.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class NoteEntryPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadNote(value);
            }
        }

        public Data.NoteDatabase NoteDatabase
        {
            get => default;
            set
            {
            }
        }

        public NoteEntryPage()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Note.
            BindingContext = new Note();
        }

        async void LoadNote(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the note and set it as the BindingContext of the page.
                Note note = await App.Database.GetNoteAsync(id);
                BindingContext = note;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
                var note = (Note)BindingContext;
                note.Date = DateTime.UtcNow;
                if (!string.IsNullOrWhiteSpace(note.Text) && !string.IsNullOrWhiteSpace(note.Titulo))
                {
                    await App.Database.SaveNoteAsync(note);
                }
            // Navigate backwards
            await Navigation.PopToRootAsync();

        }
    }
}