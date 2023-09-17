using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoPREP.Models;

public partial class DbPrepContext : DbContext
{
    public DbPrepContext()
    {
    }

    public DbPrepContext(DbContextOptions<DbPrepContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CondicionPaciente> CondicionPacientes { get; set; }

    public virtual DbSet<DatosGenerale> DatosGenerales { get; set; }

    public virtual DbSet<DatosGenerales1329> DatosGenerales1329s { get; set; }

    public virtual DbSet<DbLog> DbLogs { get; set; }

    public virtual DbSet<ElegibilidadPrep> ElegibilidadPreps { get; set; }

    public virtual DbSet<ElegibilidadPrep1329> ElegibilidadPrep1329s { get; set; }

    public virtual DbSet<EstatusGestionPaciente> EstatusGestionPacientes { get; set; }

    public virtual DbSet<EstatusSolicitud> EstatusSolicituds { get; set; }

    public virtual DbSet<FormularioPrep> FormularioPreps { get; set; }

    public virtual DbSet<FormularioPrep1329> FormularioPrep1329s { get; set; }

    public virtual DbSet<GestionPaciente> GestionPacientes { get; set; }

    public virtual DbSet<It> Its { get; set; }

    public virtual DbSet<Its1329> Its1329s { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<PreferenciaSexual> PreferenciaSexuals { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SaiListado> SaiListados { get; set; }

    public virtual DbSet<Seccione> Secciones { get; set; }

    public virtual DbSet<Seguimiento> Seguimientos { get; set; }

    public virtual DbSet<Seguimientos1329> Seguimientos1329s { get; set; }

    public virtual DbSet<SeguimientosPrueba> SeguimientosPruebas { get; set; }

    public virtual DbSet<TratamientoPrep> TratamientoPreps { get; set; }

    public virtual DbSet<TratamientoPreps1329> TratamientoPreps1329s { get; set; }

    public virtual DbSet<UsuarioRole> UsuarioRoles { get; set; }

    public virtual DbSet<Validacione> Validaciones { get; set; }

    public virtual DbSet<VwPrepFormularioPrEpTodo> VwPrepFormularioPrEpTodos { get; set; }

    public virtual DbSet<VwPrepFormularioPrEpUltimo> VwPrepFormularioPrEpUltimos { get; set; }

    public virtual DbSet<VwPrepPacientesElegibilidadUltimo> VwPrepPacientesElegibilidadUltimos { get; set; }

    public virtual DbSet<VwPrepPacientesItsTodo> VwPrepPacientesItsTodos { get; set; }

    public virtual DbSet<VwPrepPacientesSeguimientosTodo> VwPrepPacientesSeguimientosTodos { get; set; }

    public virtual DbSet<VwPrepPacientesSeguimientosUltimo> VwPrepPacientesSeguimientosUltimos { get; set; }

    public virtual DbSet<VwPrepPacientesTratamientosTodo> VwPrepPacientesTratamientosTodos { get; set; }

    public virtual DbSet<VwPrepPacientesTratamientosUltimo> VwPrepPacientesTratamientosUltimos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DB_PREP; TrustServerCertificate=True; Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CondicionPaciente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Condicio__3214EC071684A5F5");

            entity.ToTable("CondicionPaciente");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<DatosGenerale>(entity =>
        {
            entity.ToTable("Datos_Generales");

            entity.HasIndex(e => new { e.Nombres, e.Apellidos, e.Sexo, e.FechaNacimiento, e.Nacionalidad }, "UC_Persona").IsUnique();

            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.Ars).HasColumnName("ARS");
            entity.Property(e => e.FechaIngresoSai)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Ingreso_SAI");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Nacimiento");
            entity.Property(e => e.NombreArs).HasColumnName("NombreARS");
            entity.Property(e => e.Nombres).HasMaxLength(100);
            entity.Property(e => e.Peso).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ServicioSai).HasColumnName("Servicio_SAI");
            entity.Property(e => e.Sexo).HasMaxLength(1);
            entity.Property(e => e.TallaPies).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TallaPulgadas).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TieneDocumentos).HasColumnName("Tiene_documentos");
            entity.Property(e => e.TipoDocumento).HasColumnName("Tipo_Documento");
        });

        modelBuilder.Entity<DatosGenerales1329>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Datos_Generales_1329");

            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.Ars).HasColumnName("ARS");
            entity.Property(e => e.FechaIngresoSai)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Ingreso_SAI");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Nacimiento");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.NombreArs).HasColumnName("NombreARS");
            entity.Property(e => e.Nombres).HasMaxLength(100);
            entity.Property(e => e.Peso).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ServicioSai).HasColumnName("Servicio_SAI");
            entity.Property(e => e.Sexo).HasMaxLength(1);
            entity.Property(e => e.TallaPies).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TallaPulgadas).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TieneDocumentos).HasColumnName("Tiene_documentos");
            entity.Property(e => e.TipoDocumento).HasColumnName("Tipo_Documento");
        });

        modelBuilder.Entity<DbLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__db_log__3214EC07D98CC934");

            entity.ToTable("db_log");

            entity.Property(e => e.FechaError)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_error");
        });

        modelBuilder.Entity<ElegibilidadPrep>(entity =>
        {
            entity.ToTable("Elegibilidad_Prep");

            entity.Property(e => e.AclaramientoCreatinina).HasColumnName("Aclaramiento_Creatinina");
            entity.Property(e => e.CargaViralPcr).HasColumnName("CargaViralPCR");
            entity.Property(e => e.CreatininaValor).HasColumnName("Creatinina_Valor");
            entity.Property(e => e.FechaElegibilidad).HasColumnType("datetime");
            entity.Property(e => e.FechaEntregaVih)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Entrega_VIH");
            entity.Property(e => e.FechaPruebaPcr)
                .HasColumnType("datetime")
                .HasColumnName("FechaPruebaPCR");
            entity.Property(e => e.FechaPruebaVih)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Prueba_VIH");
            entity.Property(e => e.FechaReintegro).HasColumnType("date");
            entity.Property(e => e.FechaResultadoCreatinina)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Resultado_Creatinina");
            entity.Property(e => e.FechaVisitaPcr)
                .HasColumnType("datetime")
                .HasColumnName("FechaVisitaPCR");
            entity.Property(e => e.FormularioPrepId).HasColumnName("Formulario_Prep_Id");
            entity.Property(e => e.ResultadoCargaViralPcr).HasColumnName("ResultadoCargaViralPCR");
            entity.Property(e => e.ResultadoCreatinina).HasColumnName("Resultado_Creatinina");
            entity.Property(e => e.ResultadoPruebaVih).HasColumnName("Resultado_Prueba_VIH");
            entity.Property(e => e.RiesgoInfeccionVih).HasColumnName("Riesgo_Infeccion_VIH");
            entity.Property(e => e.SeronegativoVih).HasColumnName("Seronegativo_VIH");
            entity.Property(e => e.SignosSintomas).HasColumnName("Signos_Sintomas");

            entity.HasOne(d => d.FormularioPrep).WithMany(p => p.ElegibilidadPreps)
                .HasForeignKey(d => d.FormularioPrepId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Formulario_PrepElegibilidad_Prep");
        });

        modelBuilder.Entity<ElegibilidadPrep1329>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Elegibilidad_Prep_1329");

            entity.Property(e => e.AclaramientoCreatinina).HasColumnName("Aclaramiento_Creatinina");
            entity.Property(e => e.CargaViralPcr).HasColumnName("CargaViralPCR");
            entity.Property(e => e.CreatininaValor).HasColumnName("Creatinina_Valor");
            entity.Property(e => e.FechaElegibilidad).HasColumnType("datetime");
            entity.Property(e => e.FechaEntregaVih)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Entrega_VIH");
            entity.Property(e => e.FechaPruebaPcr)
                .HasColumnType("datetime")
                .HasColumnName("FechaPruebaPCR");
            entity.Property(e => e.FechaPruebaVih)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Prueba_VIH");
            entity.Property(e => e.FechaReintegro).HasColumnType("date");
            entity.Property(e => e.FechaResultadoCreatinina)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Resultado_Creatinina");
            entity.Property(e => e.FechaVisitaPcr)
                .HasColumnType("datetime")
                .HasColumnName("FechaVisitaPCR");
            entity.Property(e => e.FormularioPrepId).HasColumnName("Formulario_Prep_Id");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ResultadoCargaViralPcr).HasColumnName("ResultadoCargaViralPCR");
            entity.Property(e => e.ResultadoCreatinina).HasColumnName("Resultado_Creatinina");
            entity.Property(e => e.ResultadoPruebaVih).HasColumnName("Resultado_Prueba_VIH");
            entity.Property(e => e.RiesgoInfeccionVih).HasColumnName("Riesgo_Infeccion_VIH");
            entity.Property(e => e.SeronegativoVih).HasColumnName("Seronegativo_VIH");
            entity.Property(e => e.SignosSintomas).HasColumnName("Signos_Sintomas");
        });

        modelBuilder.Entity<EstatusGestionPaciente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EstatusG__3214EC07E85AF013");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<EstatusSolicitud>(entity =>
        {
            entity.ToTable("Estatus_Solicitud");
        });

        modelBuilder.Entity<FormularioPrep>(entity =>
        {
            entity.ToTable("Formulario_Prep");

            entity.Property(e => e.CantParejasSexuales).HasColumnName("Cant_Parejas_Sexuales");
            entity.Property(e => e.DatosGeneralesId).HasColumnName("Datos_Generales_Id");
            entity.Property(e => e.DrogasIlicitas).HasColumnName("Drogas_Ilicitas");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaReintegro).HasColumnType("date");
            entity.Property(e => e.HaRecibidoProfilaxisPostExposicion).HasColumnName("HaRecibido_Profilaxis_PostExposicion");
            entity.Property(e => e.HaTenidoIts).HasColumnName("HaTenido_ITS");
            entity.Property(e => e.SexoConVihpositivo).HasColumnName("SexoConVIHPositivo");
            entity.Property(e => e.SexoPorBienes).HasColumnName("Sexo_Por_Bienes");
            entity.Property(e => e.SexoPorBienesPareja).HasColumnName("Sexo_Por_Bienes_Pareja");
            entity.Property(e => e.SexoSinProteccion).HasColumnName("Sexo_Sin_Proteccion");
            entity.Property(e => e.TienesRelacionesCon).HasColumnName("Tienes_Relaciones_Con");

            entity.HasOne(d => d.DatosGenerales).WithMany(p => p.FormularioPreps)
                .HasForeignKey(d => d.DatosGeneralesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Datos_GeneralesFormulario_Prep");
        });

        modelBuilder.Entity<FormularioPrep1329>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Formulario_Prep_1329");

            entity.Property(e => e.CantParejasSexuales).HasColumnName("Cant_Parejas_Sexuales");
            entity.Property(e => e.DatosGeneralesId).HasColumnName("Datos_Generales_Id");
            entity.Property(e => e.DrogasIlicitas).HasColumnName("Drogas_Ilicitas");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaReintegro).HasColumnType("date");
            entity.Property(e => e.HaRecibidoProfilaxisPostExposicion).HasColumnName("HaRecibido_Profilaxis_PostExposicion");
            entity.Property(e => e.HaTenidoIts).HasColumnName("HaTenido_ITS");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.SexoConVihpositivo).HasColumnName("SexoConVIHPositivo");
            entity.Property(e => e.SexoPorBienes).HasColumnName("Sexo_Por_Bienes");
            entity.Property(e => e.SexoPorBienesPareja).HasColumnName("Sexo_Por_Bienes_Pareja");
            entity.Property(e => e.SexoSinProteccion).HasColumnName("Sexo_Sin_Proteccion");
            entity.Property(e => e.TienesRelacionesCon).HasColumnName("Tienes_Relaciones_Con");
        });

        modelBuilder.Entity<GestionPaciente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GestionP__3214EC07497D3999");

            entity.Property(e => e.DatosGeneralesId).HasColumnName("Datos_Generales_Id");
            entity.Property(e => e.EstatusSolicitud).HasColumnName("Estatus_Solicitud");
            entity.Property(e => e.FechaEnvio).HasColumnType("datetime");
            entity.Property(e => e.FechaRecepcion).HasColumnType("datetime");

            entity.HasOne(d => d.DatosGenerales).WithMany(p => p.GestionPacientes)
                .HasForeignKey(d => d.DatosGeneralesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GestionPacientesDatosGenerales");
        });

        modelBuilder.Entity<It>(entity =>
        {
            entity.ToTable("ITS");

            entity.Property(e => e.ElegibilidadPrepId).HasColumnName("Elegibilidad_Prep_Id");
            entity.Property(e => e.HbsAg).HasColumnName("HBsAg");
            entity.Property(e => e.HbsAgFecha)
                .HasColumnType("datetime")
                .HasColumnName("HBsAg_Fecha");
            entity.Property(e => e.HepatitisC).HasColumnName("Hepatitis_C");
            entity.Property(e => e.HepatitisCFecha)
                .HasColumnType("datetime")
                .HasColumnName("Hepatitis_C_Fecha");
            entity.Property(e => e.ItsDiagnosticoPresuntivo).HasColumnName("ITS_Diagnostico_Presuntivo");
            entity.Property(e => e.Nr).HasColumnName("NR");
            entity.Property(e => e.SecrecionUretral).HasColumnName("Secrecion_uretral");
            entity.Property(e => e.SecrecionVaginal).HasColumnName("Secrecion_vaginal");
            entity.Property(e => e.SifilisFecha)
                .HasColumnType("datetime")
                .HasColumnName("Sifilis_Fecha");
            entity.Property(e => e.UlceraGenital).HasColumnName("Ulcera_genital");
            entity.Property(e => e.Urea).HasColumnName("UREA");
            entity.Property(e => e.VerrugasGenitales).HasColumnName("Verrugas_genitales");

            entity.HasOne(d => d.ElegibilidadPrep).WithMany(p => p.Its)
                .HasForeignKey(d => d.ElegibilidadPrepId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Elegibilidad_PrepITS");
        });

        modelBuilder.Entity<Its1329>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ITS_1329");

            entity.Property(e => e.ElegibilidadPrepId).HasColumnName("Elegibilidad_Prep_Id");
            entity.Property(e => e.HbsAg).HasColumnName("HBsAg");
            entity.Property(e => e.HbsAgFecha)
                .HasColumnType("datetime")
                .HasColumnName("HBsAg_Fecha");
            entity.Property(e => e.HepatitisC).HasColumnName("Hepatitis_C");
            entity.Property(e => e.HepatitisCFecha)
                .HasColumnType("datetime")
                .HasColumnName("Hepatitis_C_Fecha");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ItsDiagnosticoPresuntivo).HasColumnName("ITS_Diagnostico_Presuntivo");
            entity.Property(e => e.Nr).HasColumnName("NR");
            entity.Property(e => e.SecrecionUretral).HasColumnName("Secrecion_uretral");
            entity.Property(e => e.SecrecionVaginal).HasColumnName("Secrecion_vaginal");
            entity.Property(e => e.SifilisFecha)
                .HasColumnType("datetime")
                .HasColumnName("Sifilis_Fecha");
            entity.Property(e => e.UlceraGenital).HasColumnName("Ulcera_genital");
            entity.Property(e => e.Urea).HasColumnName("UREA");
            entity.Property(e => e.VerrugasGenitales).HasColumnName("Verrugas_genitales");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.Property(e => e.Estatus)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Seccion).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.SeccionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SeccionPermiso");
        });

        modelBuilder.Entity<PreferenciaSexual>(entity =>
        {
            entity.ToTable("Preferencia_Sexual");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasMany(d => d.Permisos).WithMany(p => p.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "RolePermiso",
                    r => r.HasOne<Permiso>().WithMany()
                        .HasForeignKey("PermisosId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RolePermiso_Permiso"),
                    l => l.HasOne<Role>().WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RolePermiso_Role"),
                    j =>
                    {
                        j.HasKey("RolesId", "PermisosId");
                        j.ToTable("RolePermiso");
                        j.IndexerProperty<int>("RolesId").HasColumnName("Roles_Id");
                        j.IndexerProperty<int>("PermisosId").HasColumnName("Permisos_Id");
                    });
        });

        modelBuilder.Entity<SaiListado>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SAI_Listado");

            entity.Property(e => e.Sai).HasColumnName("SAI");
            entity.Property(e => e.SaiId).HasColumnName("SAI_Id");
        });

        modelBuilder.Entity<Seguimiento>(entity =>
        {
            entity.Property(e => e.AdherenciaCantidadComprimidos).HasColumnName("Adherencia_Cantidad_Comprimidos");
            entity.Property(e => e.AsesoramientoAdherencia).HasColumnName("Asesoramiento_Adherencia");
            entity.Property(e => e.AsesoramientoRiesgos).HasColumnName("Asesoramiento_Riesgos");
            entity.Property(e => e.ConsultaSignosInfeccion).HasColumnName("Consulta_signos_infeccion");
            entity.Property(e => e.EfectosSecundarios).HasColumnName("Efectos_Secundarios");
            entity.Property(e => e.ElegibilidadPrepId).HasColumnName("Elegibilidad_Prep_Id");
            entity.Property(e => e.EntregaCondones).HasColumnName("Entrega_Condones");
            entity.Property(e => e.FechaProximoSeguimiento).HasColumnType("datetime");
            entity.Property(e => e.FechaPruebaVih)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Prueba_VIH");
            entity.Property(e => e.FechaRegistroSeguimiento).HasColumnType("date");
            entity.Property(e => e.FechaSeguimiento).HasColumnType("datetime");
            entity.Property(e => e.HbsAg).HasColumnName("HBsAg");
            entity.Property(e => e.HbsAgFecha)
                .HasColumnType("datetime")
                .HasColumnName("HBsAg_Fecha");
            entity.Property(e => e.HepatitisC).HasColumnName("Hepatitis_C");
            entity.Property(e => e.HepatitisCFecha)
                .HasColumnType("datetime")
                .HasColumnName("Hepatitis_C_Fecha");
            entity.Property(e => e.ItsDiagnosticoPresuntivo).HasColumnName("ITS_Diagnostico_Presuntivo");
            entity.Property(e => e.MesesPrescripcion).HasColumnName("Meses_prescripcion");
            entity.Property(e => e.NuevaItsdiagnosticada).HasColumnName("NuevaITSDiagnosticada");
            entity.Property(e => e.PrepArvTafFtc).HasColumnName("Prep_ARV_TAF_FTC");
            entity.Property(e => e.PrepArvTdf3tc).HasColumnName("Prep_ARV_TDF_3TC");
            entity.Property(e => e.PrepArvTdfFtc).HasColumnName("Prep_ARV_TDF_FTC");
            entity.Property(e => e.ResultadoCreatinina).HasColumnName("Resultado_Creatinina");
            entity.Property(e => e.ResultadoPruebaVih).HasColumnName("Resultado_Prueba_VIH");
            entity.Property(e => e.SecrecionUretral).HasColumnName("Secrecion_uretral");
            entity.Property(e => e.SecrecionVaginal).HasColumnName("Secrecion_vaginal");
            entity.Property(e => e.SifilisFecha)
                .HasColumnType("datetime")
                .HasColumnName("Sifilis_Fecha");
            entity.Property(e => e.SignosVitalesFc).HasColumnName("SignosVitales_FC");
            entity.Property(e => e.SignosVitalesFr).HasColumnName("SignosVitales_FR");
            entity.Property(e => e.SignosVitalesTa).HasColumnName("SignosVItales_TA");
            entity.Property(e => e.TallaPies).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TallaPulgadas).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UlceraGenital).HasColumnName("Ulcera_genital");
            entity.Property(e => e.Urea).HasColumnName("UREA");
            entity.Property(e => e.VerrugasGenitales).HasColumnName("Verrugas_genitales");

            entity.HasOne(d => d.ElegibilidadPrep).WithMany(p => p.Seguimientos)
                .HasForeignKey(d => d.ElegibilidadPrepId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SeguimientosElegibilidad_Prep");
        });

        modelBuilder.Entity<Seguimientos1329>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Seguimientos_1329");

            entity.Property(e => e.AdherenciaCantidadComprimidos).HasColumnName("Adherencia_Cantidad_Comprimidos");
            entity.Property(e => e.AsesoramientoAdherencia).HasColumnName("Asesoramiento_Adherencia");
            entity.Property(e => e.AsesoramientoRiesgos).HasColumnName("Asesoramiento_Riesgos");
            entity.Property(e => e.ConsultaSignosInfeccion).HasColumnName("Consulta_signos_infeccion");
            entity.Property(e => e.EfectosSecundarios).HasColumnName("Efectos_Secundarios");
            entity.Property(e => e.ElegibilidadPrepId).HasColumnName("Elegibilidad_Prep_Id");
            entity.Property(e => e.EntregaCondones).HasColumnName("Entrega_Condones");
            entity.Property(e => e.FechaProximoSeguimiento).HasColumnType("datetime");
            entity.Property(e => e.FechaPruebaVih)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Prueba_VIH");
            entity.Property(e => e.FechaRegistroSeguimiento).HasColumnType("date");
            entity.Property(e => e.FechaSeguimiento).HasColumnType("datetime");
            entity.Property(e => e.HbsAg).HasColumnName("HBsAg");
            entity.Property(e => e.HbsAgFecha)
                .HasColumnType("datetime")
                .HasColumnName("HBsAg_Fecha");
            entity.Property(e => e.HepatitisC).HasColumnName("Hepatitis_C");
            entity.Property(e => e.HepatitisCFecha)
                .HasColumnType("datetime")
                .HasColumnName("Hepatitis_C_Fecha");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ItsDiagnosticoPresuntivo).HasColumnName("ITS_Diagnostico_Presuntivo");
            entity.Property(e => e.MesesPrescripcion).HasColumnName("Meses_prescripcion");
            entity.Property(e => e.NuevaItsdiagnosticada).HasColumnName("NuevaITSDiagnosticada");
            entity.Property(e => e.PrepArvTafFtc).HasColumnName("Prep_ARV_TAF_FTC");
            entity.Property(e => e.PrepArvTdf3tc).HasColumnName("Prep_ARV_TDF_3TC");
            entity.Property(e => e.PrepArvTdfFtc).HasColumnName("Prep_ARV_TDF_FTC");
            entity.Property(e => e.ResultadoCreatinina).HasColumnName("Resultado_Creatinina");
            entity.Property(e => e.ResultadoPruebaVih).HasColumnName("Resultado_Prueba_VIH");
            entity.Property(e => e.SecrecionUretral).HasColumnName("Secrecion_uretral");
            entity.Property(e => e.SecrecionVaginal).HasColumnName("Secrecion_vaginal");
            entity.Property(e => e.SifilisFecha)
                .HasColumnType("datetime")
                .HasColumnName("Sifilis_Fecha");
            entity.Property(e => e.SignosVitalesFc).HasColumnName("SignosVitales_FC");
            entity.Property(e => e.SignosVitalesFr).HasColumnName("SignosVitales_FR");
            entity.Property(e => e.SignosVitalesTa).HasColumnName("SignosVItales_TA");
            entity.Property(e => e.TallaPies).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TallaPulgadas).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UlceraGenital).HasColumnName("Ulcera_genital");
            entity.Property(e => e.Urea).HasColumnName("UREA");
            entity.Property(e => e.VerrugasGenitales).HasColumnName("Verrugas_genitales");
        });

        modelBuilder.Entity<SeguimientosPrueba>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Seguimie__3214EC07083FE41D");

            entity.ToTable("Seguimientos_Pruebas");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Creatinina).HasDefaultValueSql("((0))");
            entity.Property(e => e.Hemograma).HasDefaultValueSql("((0))");
            entity.Property(e => e.HepatitisB)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Hepatitis_B");
            entity.Property(e => e.HepatitisC)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Hepatitis_C");
            entity.Property(e => e.Urea)
                .HasDefaultValueSql("((0))")
                .HasColumnName("UREA");
            entity.Property(e => e.Vdrl)
                .HasDefaultValueSql("((0))")
                .HasColumnName("VDRL");
            entity.Property(e => e.Vih)
                .HasDefaultValueSql("((0))")
                .HasColumnName("VIH");
        });

        modelBuilder.Entity<TratamientoPrep>(entity =>
        {
            entity.Property(e => e.ElegibilidadPrepId).HasColumnName("Elegibilidad_Prep_Id");
            entity.Property(e => e.EstadoVihAlInterrumpir).HasColumnName("Estado_VIH_AlInterrumpir");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Inicio");
            entity.Property(e => e.FechaSeguimiento).HasColumnType("datetime");
            entity.Property(e => e.MesesPrescripcion).HasColumnName("Meses_prescripcion");
            entity.Property(e => e.MotivosInterrupcionPrep).HasColumnName("Motivos_Interrupcion_Prep");
            entity.Property(e => e.PrepArvTafFtc).HasColumnName("Prep_ARV_TAF_FTC");
            entity.Property(e => e.PrepArvTdf3tc).HasColumnName("Prep_ARV_TDF_3TC");
            entity.Property(e => e.PrepArvTdfFtc).HasColumnName("Prep_ARV_TDF_FTC");
            entity.Property(e => e.PrepSuspendida)
                .HasColumnType("datetime")
                .HasColumnName("Prep_Suspendida");

            entity.HasOne(d => d.ElegibilidadPrep).WithMany(p => p.TratamientoPreps)
                .HasForeignKey(d => d.ElegibilidadPrepId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TratamientoPrepElegibilidad_Prep");
        });

        modelBuilder.Entity<TratamientoPreps1329>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TratamientoPreps_1329");

            entity.Property(e => e.ElegibilidadPrepId).HasColumnName("Elegibilidad_Prep_Id");
            entity.Property(e => e.EstadoVihAlInterrumpir).HasColumnName("Estado_VIH_AlInterrumpir");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Inicio");
            entity.Property(e => e.FechaSeguimiento).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.MesesPrescripcion).HasColumnName("Meses_prescripcion");
            entity.Property(e => e.MotivosInterrupcionPrep).HasColumnName("Motivos_Interrupcion_Prep");
            entity.Property(e => e.PrepArvTafFtc).HasColumnName("Prep_ARV_TAF_FTC");
            entity.Property(e => e.PrepArvTdf3tc).HasColumnName("Prep_ARV_TDF_3TC");
            entity.Property(e => e.PrepArvTdfFtc).HasColumnName("Prep_ARV_TDF_FTC");
            entity.Property(e => e.PrepSuspendida)
                .HasColumnType("datetime")
                .HasColumnName("Prep_Suspendida");
        });

        modelBuilder.Entity<UsuarioRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UsuarioRole");

            entity.Property(e => e.IdCentro).HasColumnName("ID_Centro");
            entity.Property(e => e.RolesId).HasColumnName("Roles_Id");

            entity.HasOne(d => d.Roles).WithMany()
                .HasForeignKey(d => d.RolesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRole_Role");
        });

        modelBuilder.Entity<Validacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Validaci__3213E83FC0507DAC");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<VwPrepFormularioPrEpTodo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Prep_FormularioPrEP_Todos");

            entity.Property(e => e.CantParejasSexuales).HasColumnName("Cant_Parejas_Sexuales");
            entity.Property(e => e.DatosGeneralesId).HasColumnName("Datos_Generales_Id");
            entity.Property(e => e.DrogasIlicitas).HasColumnName("Drogas_Ilicitas");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaReintegro).HasColumnType("date");
            entity.Property(e => e.HaRecibidoProfilaxisPostExposicion).HasColumnName("HaRecibido_Profilaxis_PostExposicion");
            entity.Property(e => e.HaTenidoIts).HasColumnName("HaTenido_ITS");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.SexoConVihpositivo).HasColumnName("SexoConVIHPositivo");
            entity.Property(e => e.SexoPorBienes).HasColumnName("Sexo_Por_Bienes");
            entity.Property(e => e.SexoPorBienesPareja).HasColumnName("Sexo_Por_Bienes_Pareja");
            entity.Property(e => e.SexoSinProteccion).HasColumnName("Sexo_Sin_Proteccion");
            entity.Property(e => e.TienesRelacionesCon).HasColumnName("Tienes_Relaciones_Con");
        });

        modelBuilder.Entity<VwPrepFormularioPrEpUltimo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Prep_FormularioPrEP_Ultimo");

            entity.Property(e => e.CantParejasSexuales).HasColumnName("Cant_Parejas_Sexuales");
            entity.Property(e => e.DatosGeneralesId).HasColumnName("Datos_Generales_Id");
            entity.Property(e => e.DrogasIlicitas).HasColumnName("Drogas_Ilicitas");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaReintegro).HasColumnType("date");
            entity.Property(e => e.HaRecibidoProfilaxisPostExposicion).HasColumnName("HaRecibido_Profilaxis_PostExposicion");
            entity.Property(e => e.HaTenidoIts).HasColumnName("HaTenido_ITS");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.SexoConVihpositivo).HasColumnName("SexoConVIHPositivo");
            entity.Property(e => e.SexoPorBienes).HasColumnName("Sexo_Por_Bienes");
            entity.Property(e => e.SexoPorBienesPareja).HasColumnName("Sexo_Por_Bienes_Pareja");
            entity.Property(e => e.SexoSinProteccion).HasColumnName("Sexo_Sin_Proteccion");
            entity.Property(e => e.TienesRelacionesCon).HasColumnName("Tienes_Relaciones_Con");
        });

        modelBuilder.Entity<VwPrepPacientesElegibilidadUltimo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Prep_Pacientes_Elegibilidad_Ultimo");

            entity.Property(e => e.AclaramientoCreatinina).HasColumnName("Aclaramiento_Creatinina");
            entity.Property(e => e.CargaViralPcr).HasColumnName("CargaViralPCR");
            entity.Property(e => e.CreatininaValor).HasColumnName("Creatinina_Valor");
            entity.Property(e => e.FechaElegibilidad).HasColumnType("datetime");
            entity.Property(e => e.FechaEntregaVih)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Entrega_VIH");
            entity.Property(e => e.FechaPruebaPcr)
                .HasColumnType("datetime")
                .HasColumnName("FechaPruebaPCR");
            entity.Property(e => e.FechaPruebaVih)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Prueba_VIH");
            entity.Property(e => e.FechaReintegro).HasColumnType("date");
            entity.Property(e => e.FechaResultadoCreatinina)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Resultado_Creatinina");
            entity.Property(e => e.FechaVisitaPcr)
                .HasColumnType("datetime")
                .HasColumnName("FechaVisitaPCR");
            entity.Property(e => e.FormularioPrepId).HasColumnName("Formulario_Prep_Id");
            entity.Property(e => e.ResultadoCargaViralPcr).HasColumnName("ResultadoCargaViralPCR");
            entity.Property(e => e.ResultadoCreatinina).HasColumnName("Resultado_Creatinina");
            entity.Property(e => e.ResultadoPruebaVih).HasColumnName("Resultado_Prueba_VIH");
            entity.Property(e => e.RiesgoInfeccionVih).HasColumnName("Riesgo_Infeccion_VIH");
            entity.Property(e => e.SeronegativoVih).HasColumnName("Seronegativo_VIH");
            entity.Property(e => e.SignosSintomas).HasColumnName("Signos_Sintomas");
        });

        modelBuilder.Entity<VwPrepPacientesItsTodo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Prep_Pacientes_ITS_Todos");

            entity.Property(e => e.ElegibilidadPrepId).HasColumnName("Elegibilidad_Prep_Id");
            entity.Property(e => e.HbsAg).HasColumnName("HBsAg");
            entity.Property(e => e.HbsAgFecha)
                .HasColumnType("datetime")
                .HasColumnName("HBsAg_Fecha");
            entity.Property(e => e.HepatitisC).HasColumnName("Hepatitis_C");
            entity.Property(e => e.HepatitisCFecha)
                .HasColumnType("datetime")
                .HasColumnName("Hepatitis_C_Fecha");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ItsDiagnosticoPresuntivo).HasColumnName("ITS_Diagnostico_Presuntivo");
            entity.Property(e => e.Nr).HasColumnName("NR");
            entity.Property(e => e.SecrecionUretral).HasColumnName("Secrecion_uretral");
            entity.Property(e => e.SecrecionVaginal).HasColumnName("Secrecion_vaginal");
            entity.Property(e => e.SifilisFecha)
                .HasColumnType("datetime")
                .HasColumnName("Sifilis_Fecha");
            entity.Property(e => e.UlceraGenital).HasColumnName("Ulcera_genital");
            entity.Property(e => e.Urea).HasColumnName("UREA");
            entity.Property(e => e.VerrugasGenitales).HasColumnName("Verrugas_genitales");
        });

        modelBuilder.Entity<VwPrepPacientesSeguimientosTodo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Prep_Pacientes_Seguimientos_Todos");

            entity.Property(e => e.AdherenciaCantidadComprimidos).HasColumnName("Adherencia_Cantidad_Comprimidos");
            entity.Property(e => e.AsesoramientoAdherencia).HasColumnName("Asesoramiento_Adherencia");
            entity.Property(e => e.AsesoramientoRiesgos).HasColumnName("Asesoramiento_Riesgos");
            entity.Property(e => e.ConsultaSignosInfeccion).HasColumnName("Consulta_signos_infeccion");
            entity.Property(e => e.EfectosSecundarios).HasColumnName("Efectos_Secundarios");
            entity.Property(e => e.ElegibilidadPrepId).HasColumnName("Elegibilidad_Prep_Id");
            entity.Property(e => e.EntregaCondones).HasColumnName("Entrega_Condones");
            entity.Property(e => e.FechaProximoSeguimiento).HasColumnType("datetime");
            entity.Property(e => e.FechaPruebaVih)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Prueba_VIH");
            entity.Property(e => e.FechaRegistroSeguimiento).HasColumnType("date");
            entity.Property(e => e.FechaSeguimiento).HasColumnType("datetime");
            entity.Property(e => e.HbsAg).HasColumnName("HBsAg");
            entity.Property(e => e.HbsAgFecha)
                .HasColumnType("datetime")
                .HasColumnName("HBsAg_Fecha");
            entity.Property(e => e.HepatitisC).HasColumnName("Hepatitis_C");
            entity.Property(e => e.HepatitisCFecha)
                .HasColumnType("datetime")
                .HasColumnName("Hepatitis_C_Fecha");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ItsDiagnosticoPresuntivo).HasColumnName("ITS_Diagnostico_Presuntivo");
            entity.Property(e => e.MesesPrescripcion).HasColumnName("Meses_prescripcion");
            entity.Property(e => e.NuevaItsdiagnosticada).HasColumnName("NuevaITSDiagnosticada");
            entity.Property(e => e.PrepArvTafFtc).HasColumnName("Prep_ARV_TAF_FTC");
            entity.Property(e => e.PrepArvTdf3tc).HasColumnName("Prep_ARV_TDF_3TC");
            entity.Property(e => e.PrepArvTdfFtc).HasColumnName("Prep_ARV_TDF_FTC");
            entity.Property(e => e.ResultadoCreatinina).HasColumnName("Resultado_Creatinina");
            entity.Property(e => e.ResultadoPruebaVih).HasColumnName("Resultado_Prueba_VIH");
            entity.Property(e => e.SecrecionUretral).HasColumnName("Secrecion_uretral");
            entity.Property(e => e.SecrecionVaginal).HasColumnName("Secrecion_vaginal");
            entity.Property(e => e.SifilisFecha)
                .HasColumnType("datetime")
                .HasColumnName("Sifilis_Fecha");
            entity.Property(e => e.SignosVitalesFc).HasColumnName("SignosVitales_FC");
            entity.Property(e => e.SignosVitalesFr).HasColumnName("SignosVitales_FR");
            entity.Property(e => e.SignosVitalesTa).HasColumnName("SignosVItales_TA");
            entity.Property(e => e.TallaPies).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TallaPulgadas).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UlceraGenital).HasColumnName("Ulcera_genital");
            entity.Property(e => e.Urea).HasColumnName("UREA");
            entity.Property(e => e.VerrugasGenitales).HasColumnName("Verrugas_genitales");
        });

        modelBuilder.Entity<VwPrepPacientesSeguimientosUltimo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Prep_Pacientes_Seguimientos_Ultimo");

            entity.Property(e => e.AdherenciaCantidadComprimidos).HasColumnName("Adherencia_Cantidad_Comprimidos");
            entity.Property(e => e.AsesoramientoAdherencia).HasColumnName("Asesoramiento_Adherencia");
            entity.Property(e => e.AsesoramientoRiesgos).HasColumnName("Asesoramiento_Riesgos");
            entity.Property(e => e.ConsultaSignosInfeccion).HasColumnName("Consulta_signos_infeccion");
            entity.Property(e => e.EfectosSecundarios).HasColumnName("Efectos_Secundarios");
            entity.Property(e => e.ElegibilidadPrepId).HasColumnName("Elegibilidad_Prep_Id");
            entity.Property(e => e.EntregaCondones).HasColumnName("Entrega_Condones");
            entity.Property(e => e.FechaProximoSeguimiento).HasColumnType("datetime");
            entity.Property(e => e.FechaPruebaVih)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Prueba_VIH");
            entity.Property(e => e.FechaRegistroSeguimiento).HasColumnType("date");
            entity.Property(e => e.FechaSeguimiento).HasColumnType("datetime");
            entity.Property(e => e.HbsAg).HasColumnName("HBsAg");
            entity.Property(e => e.HbsAgFecha)
                .HasColumnType("datetime")
                .HasColumnName("HBsAg_Fecha");
            entity.Property(e => e.HepatitisC).HasColumnName("Hepatitis_C");
            entity.Property(e => e.HepatitisCFecha)
                .HasColumnType("datetime")
                .HasColumnName("Hepatitis_C_Fecha");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ItsDiagnosticoPresuntivo).HasColumnName("ITS_Diagnostico_Presuntivo");
            entity.Property(e => e.MesesPrescripcion).HasColumnName("Meses_prescripcion");
            entity.Property(e => e.NuevaItsdiagnosticada).HasColumnName("NuevaITSDiagnosticada");
            entity.Property(e => e.PrepArvTafFtc).HasColumnName("Prep_ARV_TAF_FTC");
            entity.Property(e => e.PrepArvTdf3tc).HasColumnName("Prep_ARV_TDF_3TC");
            entity.Property(e => e.PrepArvTdfFtc).HasColumnName("Prep_ARV_TDF_FTC");
            entity.Property(e => e.ResultadoCreatinina).HasColumnName("Resultado_Creatinina");
            entity.Property(e => e.ResultadoPruebaVih).HasColumnName("Resultado_Prueba_VIH");
            entity.Property(e => e.SecrecionUretral).HasColumnName("Secrecion_uretral");
            entity.Property(e => e.SecrecionVaginal).HasColumnName("Secrecion_vaginal");
            entity.Property(e => e.SifilisFecha)
                .HasColumnType("datetime")
                .HasColumnName("Sifilis_Fecha");
            entity.Property(e => e.SignosVitalesFc).HasColumnName("SignosVitales_FC");
            entity.Property(e => e.SignosVitalesFr).HasColumnName("SignosVitales_FR");
            entity.Property(e => e.SignosVitalesTa).HasColumnName("SignosVItales_TA");
            entity.Property(e => e.TallaPies).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TallaPulgadas).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UlceraGenital).HasColumnName("Ulcera_genital");
            entity.Property(e => e.Urea).HasColumnName("UREA");
            entity.Property(e => e.VerrugasGenitales).HasColumnName("Verrugas_genitales");
        });

        modelBuilder.Entity<VwPrepPacientesTratamientosTodo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Prep_Pacientes_Tratamientos_Todos");

            entity.Property(e => e.ElegibilidadPrepId).HasColumnName("Elegibilidad_Prep_Id");
            entity.Property(e => e.EstadoVihAlInterrumpir).HasColumnName("Estado_VIH_AlInterrumpir");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Inicio");
            entity.Property(e => e.FechaSeguimiento).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.MesesPrescripcion).HasColumnName("Meses_prescripcion");
            entity.Property(e => e.MotivosInterrupcionPrep).HasColumnName("Motivos_Interrupcion_Prep");
            entity.Property(e => e.PrepArvTafFtc).HasColumnName("Prep_ARV_TAF_FTC");
            entity.Property(e => e.PrepArvTdf3tc).HasColumnName("Prep_ARV_TDF_3TC");
            entity.Property(e => e.PrepArvTdfFtc).HasColumnName("Prep_ARV_TDF_FTC");
            entity.Property(e => e.PrepSuspendida)
                .HasColumnType("datetime")
                .HasColumnName("Prep_Suspendida");
        });

        modelBuilder.Entity<VwPrepPacientesTratamientosUltimo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Prep_Pacientes_Tratamientos_Ultimo");

            entity.Property(e => e.ElegibilidadPrepId).HasColumnName("Elegibilidad_Prep_Id");
            entity.Property(e => e.EstadoVihAlInterrumpir).HasColumnName("Estado_VIH_AlInterrumpir");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Inicio");
            entity.Property(e => e.FechaSeguimiento).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.MesesPrescripcion).HasColumnName("Meses_prescripcion");
            entity.Property(e => e.MotivosInterrupcionPrep).HasColumnName("Motivos_Interrupcion_Prep");
            entity.Property(e => e.PrepArvTafFtc).HasColumnName("Prep_ARV_TAF_FTC");
            entity.Property(e => e.PrepArvTdf3tc).HasColumnName("Prep_ARV_TDF_3TC");
            entity.Property(e => e.PrepArvTdfFtc).HasColumnName("Prep_ARV_TDF_FTC");
            entity.Property(e => e.PrepSuspendida)
                .HasColumnType("datetime")
                .HasColumnName("Prep_Suspendida");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
