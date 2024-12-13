using Domain.Interfaces;
using Domain.Model;

namespace Domain.Services {
    public class ReporteService : IReporteService {
        private readonly ClinicaContext _context;
        public ReporteService(ClinicaContext context) {
            _context = context;
        }

        public IEnumerable<ReporteTurnosPorMes> GetReporteTurnosPorMes() {
            var reporte = new List<ReporteTurnosPorMes>();
            var turnos = _context.Turnos.ToList();
            var meses = new List<string> { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            var currentYear = System.DateTime.Now.Year;
            foreach (var mes in meses) {
                var cantidad = turnos.Where(t => t.FechaHora.Month == meses.IndexOf(mes) + 1).Count();
                reporte.Add(new ReporteTurnosPorMes { Mes = mes, Cantidad = cantidad });
            }
            return reporte;
        }
        public IEnumerable<ReporteTurnosPorEstados> GetReporteTurnosPorEstados() {
            var reporte = new List<ReporteTurnosPorEstados>();
            var turnos = _context.Turnos.ToList();
            var estados = new List<EstadoTurno> { EstadoTurno.Reservado, EstadoTurno.Cancelado, EstadoTurno.Completado, EstadoTurno.Ausente };
            foreach (var estado in estados) {
                var cantidad = turnos.Where(t => t.Estado == estado).Count();
                reporte.Add(new ReporteTurnosPorEstados { Estado = estado.ToString(), Cantidad = cantidad });
            }
            return reporte;
        }
    }
}
