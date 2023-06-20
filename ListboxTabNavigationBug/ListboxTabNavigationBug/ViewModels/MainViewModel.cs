using ReactiveUI;
using System.Collections.ObjectModel;

namespace ListboxTabNavigationBug.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            _testObjects = GenList();
        }

        private ReadOnlyObservableCollection<TestObject> GenList()
        {
            ObservableCollection<TestObject> tmp = new();
            for(int i = 0; i < 40; i++)
            {
                tmp.Add(new TestObject(i.ToString()));
            }
            return new ReadOnlyObservableCollection<TestObject>(tmp);
        }

        public void NewList()
        {
            TestObjects = GenList();
        }

        public string Greeting => "Welcome to Avalonia!";

        private ReadOnlyObservableCollection<TestObject> _testObjects;
        public ReadOnlyObservableCollection<TestObject> TestObjects 
        { get => _testObjects; private set => this.RaiseAndSetIfChanged(ref _testObjects, value); }
    }

    public class TestObject : ReactiveObject
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        public TestObject(string name)
        {
            _name = name;
        }
    }
}