using Domain.Model;

namespace Domain.Interfaces {
    public interface IReporteService {
        IEnumerable<ReporteTurnosPorMes> GetReporteTurnosPorMes();
        IEnumerable<ReporteTurnosPorEstados> GetReporteTurnosPorEstados();
    }
}