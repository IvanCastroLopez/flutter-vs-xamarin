using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZenNotes.Models;

namespace ZenNotes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteVisualPage : ContentPage
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

        public NoteEntryPage NoteEntryPage
        {
            get => default;
            set
            {
            }
        }

        public NoteVisualPage()
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

        async void OnEditButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await Navigation.PushAsync(new NoteEntryPage
            {
                ItemId = note.ID.ToString()
            });

        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.Database.DeleteNoteAsync(note);

            // Navigate backwards
            await Navigation.PopAsync();
        }
    }
}