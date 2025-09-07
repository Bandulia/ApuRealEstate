using System.Collections.ObjectModel;
using ApuRealEstate.Estate; // <-- adjust to your domain namespace

namespace ApuRealEstate.Wpf.ViewModels;

public sealed class MainViewModel : BaseViewModel
{
    public ObservableCollection<IEstate> Estates { get; } = new();

    private IEstate? _selected;
    public IEstate? Selected
    {
        get => _selected;
        set => SetProperty(ref _selected, value);
    }

    public RelayCommand LoadDemoCommand { get; }

    public MainViewModel()
    {
        LoadDemoCommand = new RelayCommand(LoadDemoData);
    }

    private void LoadDemoData()
    {
        Estates.Clear();

        // TODO: replace with real data. For now demo:
        Estates.Add(new Residentials.Villa(
            id: "RES-1",
            address: new Address { Street = "Main St 1", ZipCode = "111 11", City = City.Paris, Country = Country.France },
            squareMeters: 120, numOfRooms: 5, legalForm: LegalForm.Ownership));

        Estates.Add(new Commercials.Shop(
            id: "COM-1",
            address: new Address { Street = "High St 20", ZipCode = "222 22", City = City.Sydney, Country = Country.Australia },
            squareMeters: 80, numOfRooms: 3, legalForm: LegalForm.Rental));
    }
}
