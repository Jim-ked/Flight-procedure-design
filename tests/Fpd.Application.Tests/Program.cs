using System;
using System.Collections.Generic;
using Fpd.Application;
using Fpd.Domain;
using Fpd.Infrastructure;

namespace Fpd.Application.Tests
{
    internal static class Program
    {
        private static void Check(bool c, string n) { if (!c) throw new Exception("FAIL: " + n); }
        public static int Main(string[] args)
        {
            var cad = new FakeCadPort(); var store = new InMemoryProjectStore(); var coordinator = new ProjectCoordinator(cad, store);
            var geometry = new GeometrySnapshot("v1", new List<Point2> { new Point2(0, 0), new Point2(1, 0) });
            coordinator.Rebuild(geometry); Check(cad.LastComputedGeometry == geometry && cad.CADDirty, "computed snapshot");
            coordinator.Accept(); Check(cad.AcceptedGeometry == geometry && !cad.CADDirty, "accepted snapshot");
            cad.SimulateManualEdit(); Check(cad.ManuallyModified && cad.CADDirty, "manual edit");
            coordinator.Detach(); Check(cad.ManuallyModified, "detach");
            coordinator.Save("p1"); var reopened = coordinator.Reopen("p1"); Check(reopened != null && reopened.AcceptedGeometry == geometry, "save/reopen");
            Console.WriteLine("CAD/store tests: PASS"); return 0;
        }
    }
}
