using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests.Loaders
{
    // Ovi testovi proveravaju logiku jednog thread-a (npr. klasa ThreadWorker).
    //
    // Ocekivana klasa ima sledece:
    //   - int Duration  — ukupno vreme izvrsavanja u sekundama
    //   - int Elapsed   — koliko sekundi je proslo
    //   - double Progress — izracunati property: (Elapsed / Duration) * 100
    //   - bool IsActive — true sve dok se ne pozove Cancel()
    //   - void Cancel() — zaustavlja thread

    [TestClass]
    public class ThreadWorkerTests
    {
        [TestMethod]
        public void Progress_WhenElapsedIsHalfOfDuration_Returns50()
        {
            // Arrange
            // Kreiraj ThreadWorker sa Duration = 50 i postavi Elapsed = 25
            // var worker = ...

            // Act
            // Uzmi vrednost Progress-a
            // double result = worker.Progress;

            // Assert
            // Ocekujemo da je progress tacno 50%
            // Assert.AreEqual(50.0, result);

            Assert.Inconclusive("Ukloni ovu liniju, kreiraj ThreadWorker i implementiraj test.");
        }

        [TestMethod]
        public void Progress_WhenCompleted_Returns100()
        {
            // Arrange
            // Kreiraj ThreadWorker sa Duration = 30 i postavi Elapsed = 30
            // var worker = ...

            // Act
            // double result = worker.Progress;

            // Assert
            // Ocekujemo 100%
            // Assert.AreEqual(100.0, result);

            Assert.Inconclusive("Ukloni ovu liniju, kreiraj ThreadWorker i implementiraj test.");
        }

        [TestMethod]
        public void Cancel_WhenCalled_SetsIsActiveToFalse()
        {
            // Arrange
            // Kreiraj ThreadWorker
            // var worker = ...

            // Act
            // Pozovi Cancel()
            // worker.Cancel();

            // Assert
            // Nakon Cancel(), IsActive treba biti false
            // Assert.IsFalse(worker.IsActive);

            Assert.Inconclusive("Ukloni ovu liniju, kreiraj ThreadWorker i implementiraj test.");
        }
    }
}
