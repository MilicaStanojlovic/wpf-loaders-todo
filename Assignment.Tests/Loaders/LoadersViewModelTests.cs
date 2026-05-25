using Assignment.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests.Loaders
{
    // Ovi testovi proveravaju logiku LoadersViewModel-a.
    //
    // Ocekivano na LoadersViewModel:
    //   - lista thread-ova (npr. IList<ThreadWorker> Threads) — uvek tacno 3
    //   - double TotalProgress — prosek Progress-a SAMO aktivnih (ne-cancelovanih) thread-ova;
    //                            vraca 0 ako su svi thread-ovi cancelovani

    [TestClass]
    public class LoadersViewModelTests
    {
        [TestMethod]
        public void Threads_OnInitialization_ContainsExactlyThree()
        {
            // Arrange
            // Kreiraj LoadersViewModel
            var vm = new LoadersViewModel();

            // Assert
            // Ocekujemo tacno 3 thread-a
            Assert.AreEqual(3, vm.Threads.Count);
        }

        [TestMethod]
        public void TotalProgress_WhenOneThreadCancelled_ExcludesCancelledThread()
        {
            // Arrange
            // Kreiraj LoadersViewModel i postavi poznate vrednosti Elapsed-a na sva 3 thread-a
            // tako da im je Progress redom 40%, 60%, 80%
            var vm = new LoadersViewModel();
            vm.Threads[0].Duration = 100;  vm.Threads[0].Elapsed = 40; // da bude 40%
            vm.Threads[1].Duration = 100;  vm.Threads[1].Elapsed = 60; // da bude 60%
            vm.Threads[2].Duration = 100;  vm.Threads[2].Elapsed = 80; // da bude 80%

            // Canceluj prvi thread
            vm.Threads[0].Cancel();

            // Act
            double result = vm.TotalProgress;

            // Assert
            // TotalProgress treba biti prosek preostala dva aktivna thread-a: (60 + 80) / 2 = 70
            Assert.AreEqual(70.0, result);
        }

        [TestMethod]
        public void TotalProgress_WhenAllThreadsCancelled_ReturnsZero()
        {
            // Arrange
            // Kreiraj LoadersViewModel i canceluj sva 3 thread-a
            var vm = new LoadersViewModel();
            vm.Threads[0].Cancel();
            vm.Threads[1].Cancel();
            vm.Threads[2].Cancel();

            // Act
            double result = vm.TotalProgress;

            // Assert
            Assert.AreEqual(0.0, result);

        }
    }
}
