using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using ZenNotes.Data;
using ZenNotes.Views;

namespace ZenNotes
{
    public partial class App : Application
    {
        static NoteDatabase database;

        // Create the database connection as a singleton.
        public static NoteDatabase Database
        {
            get
            {
                if (database == null)
                {
                    var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3");
                    database = new NoteDatabase(databasePath);
                }
                return database;
            }
        }


        public NotesPages NotesPages
        {
            get => default;
            set
            {
            }
        }

        public NotesPages NotesPages1
        {
            get => default;
            set
            {
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new NotesPages());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
