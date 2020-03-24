using Data;
using Data.Interfaces;
using Data.Models;
using Data.Repositories;
using Domain;
using Domain.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainViewModel mainViewModel;
        protected override void OnStartup(StartupEventArgs e)
            {
            var serviceProvider = new ServiceCollection().AddDbContext<DataDbContext>()
                    .AddSingleton<IMapper<IEnumerable<Frame>, IEnumerable<FrameModel>>, FrameMapper>()
                    .AddSingleton<IMapper<IEnumerable<Material>, IEnumerable<MaterialModel>>, MaterialMapper>()
                    .AddScoped<IRepository<FrameModel>, FrameRepository>()
                    .AddScoped<IRepository<MaterialModel>, MaterialRepository>()
                    .AddScoped<IUnitOfWork, UnitOfWork>()
                    .AddTransient<IOrderInteractor, OrderInteractor>()
                    .AddTransient<IFrameInteractor, FrameInteractor>()
                    .BuildServiceProvider();


            var frameInteractor = serviceProvider.GetService<IFrameInteractor>();
            var orderInteracto = serviceProvider.GetService<IOrderInteractor>();

            mainViewModel = new MainViewModel(frameInteractor, orderInteracto);

            new MainWindow { DataContext = mainViewModel };
            MainWindow.Show();
        }
    }

    
}
