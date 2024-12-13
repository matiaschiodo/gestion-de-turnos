using Domain.Interfaces;
using Domain.Model;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.EndPoints {
    public class ReporteEndpoint {
    public ReporteEndpoint(WebApplication app, IReporteService service) {
            app.MapGet("/reporte/turnos-por-mes", () => {
                var reportes = service.GetReporteTurnosPorMes();
                return Results.Ok(reportes);
            }).WithName("GetReportePorMes").WithOpenApi();

            app.MapGet("/reporte/turnos-por-estados", () => {
                var reportes = service.GetReporteTurnosPorEstados();
                return Results.Ok(reportes);
            }).WithName("GetReportePorEstado").WithOpenApi();
        }
    }
}