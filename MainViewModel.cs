using System.Windows.Input;

namespace XamlCompile_Binding;

public class MainViewModel
{
    private List<Person> people = new List<Person> () {
        new Person("Bob","Smith"),
        new Person("Jim","Brown")
    };
    public List<Person> People => people;

    private void DoSomethingMethod(object commandParam)
    {
        if (commandParam is Person p)
            Application.Current?.MainPage?.DisplayAlert("Worked", p.Name, "OK");
        else if (commandParam is null)
            Application.Current?.MainPage?.DisplayAlert("Failed", "Command parameter was null", "OK");
        else
            Application.Current?.MainPage?.DisplayAlert("Failed", "Command parameter was not a Person", "OK");
    }
    public ICommand DoSomething => new Command(DoSomethingMethod);
}

public class Person(string firstName, string lastName)
{
    public string Name => lastName+", " + firstName;
}
