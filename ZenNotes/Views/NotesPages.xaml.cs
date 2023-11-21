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
    public partial class NotesPages : ContentPage
    {
        private readonly string[] colorArray = { "FFD54FFF", "AED581FF", "4FC3F7FF", "FFB74DFF", "FF80ABFF", "A7FFEBFF" };

        public NotesPages()
        {
            InitializeComponent();
        }

        public NoteEntryPage NoteEntryPage
        {
            get => default;
            set
            {
            }
        }

        public NoteVisualPage NoteVisualPage
        {
            get => default;
            set
            {
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve all the notes from the database, and set them as the
            // data source for the CollectionView.
            collectionView.ItemsSource = await App.Database.GetNotesAsync();
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the NoteEntryPage, without passing any data.
            await Navigation.PushAsync(new NoteEntryPage());
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the NoteEntryPage, passing the ID as a query parameter.
                Note note = (Note)e.CurrentSelection.FirstOrDefault();
                await Navigation.PushAsync(new NoteVisualPage
                {
                    ItemId = note.ID.ToString()
                });
            }
        }

        public Color GetRandomColor()
        {
            Random random = new Random();

            int randomNumber = random.Next(0, 5);

            return Color.FromHex(colorArray[randomNumber]);
        }
    }
}
