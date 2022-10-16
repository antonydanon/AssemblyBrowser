using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AssemblyBrowserCore.Service;
using AssemblyBrowserDesktopApp.Model;
using AssemblyBrowserDesktopApp.ViewModel.Command;
using AssemblyBrowserDesktopApp.ViewModel.Utils;
using Microsoft.Win32;

namespace AssemblyBrowserDesktopApp.ViewModel
{
    public class NodeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private NodeConverter NodeConverter { get; } = new();
        public List<Node> Nodes { get; set; }

        private string _assemblyPath;
        public string AssemblyPath
        {
            get => _assemblyPath;
            set
            {
                _assemblyPath = value;
                try
                {
                    AssemblyService assemblyService = new(_assemblyPath); 
                    Nodes = NodeConverter.ConvertAssemblyInfoInNodes(assemblyService.GetAssemblyInfo());
                }
                catch (Exception e)
                {
                    _assemblyPath = e.Message;
                    Console.WriteLine(_assemblyPath);
                }
                OnPropertyChanged(nameof(Nodes));
            }
        }

        public ICommand OpenFileCommand => new OpenFileCommand(obj => OpenAssembly());
    
        private void OpenAssembly()
        {
            var fileDialog = new OpenFileDialog
            {
                Filter = "Assemblies|*.dll", Title = "Select assembly", Multiselect = false
            };
                
            var isOpen = fileDialog.ShowDialog() ;

            if (isOpen == null || !isOpen.Value) return;
            AssemblyPath = fileDialog.FileName;
            OnPropertyChanged(nameof(AssemblyPath));
        }    
    }
}