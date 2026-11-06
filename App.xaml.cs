using ftibantaS5.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ftibantaS5
{
    public partial class App : Application
        
    {

        public static PersonRepository _personRepo { get; private set; }

        public App(PersonRepository repo)
        {
            InitializeComponent();
            _personRepo = repo;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.vPersona());
        }
    }
}