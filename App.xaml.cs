using cVeraS5.Repositories;

namespace cVeraS5;

public partial class App : Application
{
    public static PersonRepository _personRepo { get; private set; }
    public App(PersonRepository personRepository)
    {
        InitializeComponent();
        _personRepo = personRepository;
    }
    protected override Window CreateWindow(IActivationState? activationState) => new(new Views.vPersona());
}
