using CommunityToolkit.Mvvm.ComponentModel;

namespace UI.ViewModels.Interfaces
{
    public interface ICheckOutViewModel
    {
        int ItemsCount { get; set; }
        double CurrentTotal { get; set; }
    }
}
