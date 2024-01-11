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

    public virtual DbSet<PacientesSai> PacientesSais { get; set; }

    public virtual DbSet<PacientesSirenp> PacientesSirenps { get; set; }

    public virtual DbSet<Paise> Paises { get; set; }

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

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioRole> UsuarioRoles { get; set; }

    public virtual DbSet<UsuariosDepartamento> UsuariosDepartamentos { get; set; }

    public virtual DbSet<Validacione> Validaciones { get; set; }

    public virtual DbSet<VwAr> VwArs { get; set; }

    public virtual DbSet<VwCentrosSaludPrEp> VwCentrosSaludPrEps { get; set; }

    public virtual DbSet<VwConsultaPadron> VwConsultaPadrons { get; set; }

    public virtual DbSet<VwEstablecimiento> VwEstablecimientos { get; set; }

    public virtual DbSet<VwMunicipio> VwMunicipios { get; set; }

    public virtual DbSet<VwNacionalidad> VwNacionalidads { get; set; }

    public virtual DbSet<VwParentesco> VwParentescos { get; set; }

    public virtual DbSet<VwPrepFormularioPrEpTodo> VwPrepFormularioPrEpTodos { get; set; }

    public virtual DbSet<VwPrepFormularioPrEpUltimo> VwPrepFormularioPrEpUltimos { get; set; }

    public virtual DbSet<VwPrepPacientesElegibilidadTodo> VwPrepPacientesElegibilidadTodos { get; set; }

    public virtual DbSet<VwPrepPacientesElegibilidadUltimo> VwPrepPacientesElegibilidadUltimos { get; set; }

    public virtual DbSet<VwPrepPacientesGeneral> VwPrepPacientesGenerals { get; set; }

    public virtual DbSet<VwPrepPacientesItsTodo> VwPrepPacientesItsTodos { get; set; }

    public virtual DbSet<VwPrepPacientesSeguimientosTodo> VwPrepPacientesSeguimientosTodos { get; set; }

    public virtual DbSet<VwPrepPacientesSeguimientosUltimo> VwPrepPacientesSeguimientosUltimos { get; set; }

    public virtual DbSet<VwPrepPacientesTratamientosTodo> VwPrepPacientesTratamientosTodos { get; set; }

    public virtual DbSet<VwPrepPacientesTratamientosUltimo> VwPrepPacientesTratamientosUltimos { get; set; }

    public virtual DbSet<VwProvincia> VwProvincias { get; set; }

    public virtual DbSet<VwRptPacientesDetalle> VwRptPacientesDetalles { get; set; }

    public virtual DbSet<VwRptPacientesTotale> VwRptPacientesTotales { get; set; }

    public virtual DbSet<VwSirenpPaciente> VwSirenpPacientes { get; set; }

    public virtual DbSet<VwUsuariosEstablecimiento> VwUsuariosEstablecimientos { get; set; }

    public virtual DbSet<VwUsuariosIntranet> VwUsuariosIntranets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=190.94.103.222,3342;Initial Catalog=DB_PREP; TrustServerCertificate=True;User Id=snsintranet;Password=Oblgg573uow4yZE8dt5L");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CondicionPaciente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Condicio__3214EC078CA79F42");

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
            entity.HasKey(e => e.Id).HasName("PK__db_log__3214EC0708C115E0");

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
            entity.HasKey(e => e.Id).HasName("PK__EstatusG__3214EC07A0DCC872");

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
            entity.HasKey(e => e.Id).HasName("PK__GestionP__3214EC07625068D0");

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

        modelBuilder.Entity<PacientesSai>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Pacientes_SAI");

            entity.Property(e => e.AfiliadoSdss).HasColumnName("AFILIADO_SDSS");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(80)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("APELLIDOS");
            entity.Property(e => e.Ars)
                .HasMaxLength(10)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("ARS");
            entity.Property(e => e.BioHand)
                .HasMaxLength(1)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("bio_hand");
            entity.Property(e => e.BioHandFinger)
                .HasMaxLength(1)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("bio_hand_finger");
            entity.Property(e => e.Cedula)
                .HasMaxLength(13)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("CEDULA");
            entity.Property(e => e.CmProcedencia).HasColumnName("CM_PROCEDENCIA");
            entity.Property(e => e.CriterioElegibilidadIniciarArv).HasColumnName("CRITERIO_ELEGIBILIDAD_INICIAR_ARV");
            entity.Property(e => e.DiagnosticoTb).HasColumnName("DIAGNOSTICO_TB");
            entity.Property(e => e.Direccion)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnType("text")
                .HasColumnName("DIRECCION");
            entity.Property(e => e.Estatus).HasColumnName("ESTATUS");
            entity.Property(e => e.EstatusTratamientoTb).HasColumnName("ESTATUS_TRATAMIENTO_TB");
            entity.Property(e => e.FappsKey)
                .HasMaxLength(20)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("FAPPS_KEY");
            entity.Property(e => e.FechaFinalizaAzitromicina)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_FINALIZA_AZITROMICINA");
            entity.Property(e => e.FechaFinalizaTmpSmx)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_FINALIZA_TMP_SMX");
            entity.Property(e => e.FechaFinalizaTpi)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_FINALIZA_TPI");
            entity.Property(e => e.FechaFinalizaTxTb)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_FINALIZA_TX_TB");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INGRESO");
            entity.Property(e => e.FechaInicioAzitromicina)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INICIO_AZITROMICINA");
            entity.Property(e => e.FechaInicioTmpSmx)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INICIO_TMP_SMX");
            entity.Property(e => e.FechaInicioTpi)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INICIO_TPI");
            entity.Property(e => e.FechaInicioTxTb)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INICIO_TX_TB");
            entity.Property(e => e.FechaLlenado)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_LLENADO");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_NACIMIENTO");
            entity.Property(e => e.FechaProximaCita)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_PROXIMA_CITA");
            entity.Property(e => e.FechaUltimaVisitaSai)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_ULTIMA_VISITA_SAI");
            entity.Property(e => e.HepatitisB).HasColumnName("HEPATITIS_B");
            entity.Property(e => e.HepatitisC).HasColumnName("HEPATITIS_C");
            entity.Property(e => e.IdPaciente)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_PACIENTE");
            entity.Property(e => e.InicioArvActual)
                .HasColumnType("datetime")
                .HasColumnName("INICIO_ARV_ACTUAL");
            entity.Property(e => e.InicioPrimerArvFecha)
                .HasColumnType("datetime")
                .HasColumnName("INICIO_PRIMER_ARV_FECHA");
            entity.Property(e => e.LabFechaResultadoCargaVira)
                .HasColumnType("datetime")
                .HasColumnName("LAB_FECHA_RESULTADO_CARGA_VIRA");
            entity.Property(e => e.LabFechaResultadoCd4)
                .HasColumnType("datetime")
                .HasColumnName("LAB_FECHA_RESULTADO_CD4");
            entity.Property(e => e.LabResultadoCargaViral)
                .HasColumnType("numeric(18, 4)")
                .HasColumnName("LAB_RESULTADO_CARGA_VIRAL");
            entity.Property(e => e.LabResultadoCd4)
                .HasColumnType("numeric(18, 4)")
                .HasColumnName("LAB_RESULTADO_CD4");
            entity.Property(e => e.ModificadoFecha)
                .HasColumnType("datetime")
                .HasColumnName("MODIFICADO_FECHA");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("MODIFICADO_POR");
            entity.Property(e => e.Municipio)
                .HasMaxLength(5)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("MUNICIPIO");
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(3)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("NACIONALIDAD");
            entity.Property(e => e.NoExpediente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("NO_EXPEDIENTE");
            entity.Property(e => e.NoIdSiai)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("NO_ID_SIAI");
            entity.Property(e => e.Nombres)
                .HasMaxLength(80)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("NOMBRES");
            entity.Property(e => e.Pasaporte)
                .HasMaxLength(30)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("PASAPORTE");
            entity.Property(e => e.Provincia)
                .HasMaxLength(5)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("PROVINCIA");
            entity.Property(e => e.PruebaSolicitada).HasColumnName("PRUEBA_SOLICITADA");
            entity.Property(e => e.Regimen)
                .HasMaxLength(3)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("REGIMEN");
            entity.Property(e => e.RegistradoFecha)
                .HasColumnType("datetime")
                .HasColumnName("REGISTRADO_FECHA");
            entity.Property(e => e.RegistradoPor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("REGISTRADO_POR");
            entity.Property(e => e.Sai).HasColumnName("SAI");
            entity.Property(e => e.SecrecionUretral).HasColumnName("SECRECION_URETRAL");
            entity.Property(e => e.Sexo)
                .HasMaxLength(2)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("SEXO");
            entity.Property(e => e.Sifilis).HasColumnName("SIFILIS");
            entity.Property(e => e.TelefonoCel)
                .HasMaxLength(12)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("TELEFONO_CEL");
            entity.Property(e => e.TelefonoRes)
                .HasMaxLength(12)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("TELEFONO_RES");
            entity.Property(e => e.TerapiaAzitromicina).HasColumnName("TERAPIA_AZITROMICINA");
            entity.Property(e => e.TerapiaIsoniacidaTpi).HasColumnName("TERAPIA_ISONIACIDA_TPI");
            entity.Property(e => e.TerapiaTrimetropinTmpSmx).HasColumnName("TERAPIA_TRIMETROPIN_TMP_SMX");
            entity.Property(e => e.TieneArs).HasColumnName("TIENE_ARS");
            entity.Property(e => e.TieneCedula).HasColumnName("TIENE_CEDULA");
            entity.Property(e => e.TienePasaporte).HasColumnName("TIENE_PASAPORTE");
            entity.Property(e => e.UlceraGenital).HasColumnName("ULCERA_GENITAL");
        });

        modelBuilder.Entity<PacientesSirenp>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Pacientes_SIRENP");

            entity.Property(e => e.CedPas)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ced_pas");
            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            entity.Property(e => e.PruebaFecha)
                .HasColumnType("date")
                .HasColumnName("PRUEBA_FECHA");
            entity.Property(e => e.ResultadoFinal).HasMaxLength(100);
        });

        modelBuilder.Entity<Paise>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Paises");

            entity.Property(e => e.IdPais)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ID_PAIS");
            entity.Property(e => e.NombreCortoEs)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_CORTO_ES");
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
            entity.HasKey(e => e.Id).HasName("PK__Seguimie__3214EC075656D14F");

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

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Usuarios");

            entity.Property(e => e.Activo)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.Cedula)
                .HasMaxLength(13)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(150)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.FechaRegistro).HasColumnType("date");
            entity.Property(e => e.FechaUltimoAcceso)
                .HasColumnType("date")
                .HasColumnName("Fecha_Ultimo_Acceso");
            entity.Property(e => e.FechaUltimoAccesoHora).HasColumnName("Fecha_Ultimo_Acceso_hora");
            entity.Property(e => e.IdGenero)
                .HasMaxLength(1)
                .IsFixedLength()
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.IdUsuario).ValueGeneratedOnAdd();
            entity.Property(e => e.NombreApellidos)
                .HasMaxLength(100)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.PasswordConfirm)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.PasswordExpira)
                .HasMaxLength(1)
                .IsFixedLength()
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.PasswordExpiraFecha).HasColumnType("datetime");
            entity.Property(e => e.Telefono)
                .HasMaxLength(12)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.TelefonoTrabajo)
                .HasMaxLength(12)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.TelefonoTrabajoExt)
                .HasMaxLength(5)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.Token)
                .HasMaxLength(15)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS");
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

        modelBuilder.Entity<UsuariosDepartamento>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Usuarios_Departamentos");

            entity.Property(e => e.DeptoDepend).HasMaxLength(155);
            entity.Property(e => e.DeptoDependSid)
                .HasMaxLength(151)
                .HasColumnName("DeptoDependSID");
            entity.Property(e => e.IdDeptoDepend)
                .HasMaxLength(15)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.IdRegion).HasMaxLength(5);
            entity.Property(e => e.Identificador)
                .HasMaxLength(10)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.Municipio)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NameEess)
                .HasMaxLength(150)
                .HasColumnName("NameEESS");
            entity.Property(e => e.Provincia)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Region)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Suspendido)
                .HasMaxLength(1)
                .UseCollation("Modern_Spanish_CI_AS");
        });

        modelBuilder.Entity<Validacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Validaci__3213E83F2CCE8E95");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<VwAr>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ars");

            entity.Property(e => e.Ars)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ARS");
            entity.Property(e => e.IdArs)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_ARS");
        });

        modelBuilder.Entity<VwCentrosSaludPrEp>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Centros_Salud_PrEP");

            entity.Property(e => e.IdCentro).HasColumnName("ID_CENTRO");
            entity.Property(e => e.IdRegion)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ID_Region");
            entity.Property(e => e.NombreCentro)
                .HasMaxLength(111)
                .IsUnicode(false);
            entity.Property(e => e.Provincia)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Srs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SRS");
        });

        modelBuilder.Entity<VwConsultaPadron>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwConsulta_Padron");

            entity.Property(e => e.Apellido1)
                .HasMaxLength(4000)
                .HasColumnName("APELLIDO1");
            entity.Property(e => e.Apellido2)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("APELLIDO2");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(4000)
                .HasColumnName("APELLIDOS");
            entity.Property(e => e.Cedula)
                .HasMaxLength(25)
                .HasColumnName("CEDULA");
            entity.Property(e => e.Direccion)
                .HasMaxLength(250)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.EstCivil)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("EST_CIVIL");
            entity.Property(e => e.FechaNac)
                .HasColumnType("date")
                .HasColumnName("FECHA_NAC");
            entity.Property(e => e.LugarNac)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("LUGAR_NAC");
            entity.Property(e => e.MunCed)
                .HasMaxLength(3)
                .HasColumnName("MUN_CED");
            entity.Property(e => e.Nombres)
                .HasMaxLength(80)
                .HasColumnName("NOMBRES");
            entity.Property(e => e.SeqCed)
                .HasMaxLength(7)
                .HasColumnName("SEQ_CED");
            entity.Property(e => e.Sexo)
                .HasMaxLength(2)
                .HasColumnName("SEXO");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("TELEFONO");
            entity.Property(e => e.VerCed)
                .HasMaxLength(1)
                .HasColumnName("VER_CED");
        });

        modelBuilder.Entity<VwEstablecimiento>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_establecimientos");

            entity.Property(e => e.Centro)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CENTRO");
            entity.Property(e => e.IdCentro).HasColumnName("ID_CENTRO");
            entity.Property(e => e.IdRegion)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ID_Region");
            entity.Property(e => e.Provincia)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Srs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SRS");
        });

        modelBuilder.Entity<VwMunicipio>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_municipios");

            entity.Property(e => e.IdMunicipio)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_Municipio");
            entity.Property(e => e.IdMunicipioJce)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID_Municipio_JCE");
            entity.Property(e => e.IdProvincia)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_Provincia");
            entity.Property(e => e.Municipio)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwNacionalidad>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Nacionalidad");

            entity.Property(e => e.FilaId)
                .ValueGeneratedOnAdd()
                .HasColumnName("FILA_ID");
            entity.Property(e => e.IdNacionalidad)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ID_NACIONALIDAD");
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("NACIONALIDAD");
        });

        modelBuilder.Entity<VwParentesco>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_parentesco");

            entity.Property(e => e.IdParentesco)
                .ValueGeneratedOnAdd()
                .HasColumnName("idParentesco");
            entity.Property(e => e.Parentesco).HasMaxLength(60);
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

        modelBuilder.Entity<VwPrepPacientesElegibilidadTodo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Prep_Pacientes_Elegibilidad_Todos");

            entity.Property(e => e.AclaramientoCreatinina).HasColumnName("Aclaramiento_Creatinina");
            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.Ars)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ARS");
            entity.Property(e => e.CargaViralPcr).HasColumnName("CargaViralPCR");
            entity.Property(e => e.Centro)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CENTRO");
            entity.Property(e => e.CreatininaValor).HasColumnName("Creatinina_Valor");
            entity.Property(e => e.FechaElegibilidad).HasColumnType("datetime");
            entity.Property(e => e.FechaEntregaVih)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Entrega_VIH");
            entity.Property(e => e.FechaIngresoSai)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Ingreso_SAI");
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
            entity.Property(e => e.IdCentro).HasColumnName("ID_CENTRO");
            entity.Property(e => e.IdRegion)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ID_Region");
            entity.Property(e => e.MunicipioResidencia)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.NacionalidadMadre)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.Nombres).HasMaxLength(100);
            entity.Property(e => e.PacienteId).HasColumnName("Paciente_Id");
            entity.Property(e => e.Peso).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Provincia)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProvinciaResidencia)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ResultadoCargaViralPcr).HasColumnName("ResultadoCargaViralPCR");
            entity.Property(e => e.ResultadoCreatinina).HasColumnName("Resultado_Creatinina");
            entity.Property(e => e.ResultadoPruebaVih).HasColumnName("Resultado_Prueba_VIH");
            entity.Property(e => e.RiesgoInfeccionVih).HasColumnName("Riesgo_Infeccion_VIH");
            entity.Property(e => e.SeronegativoVih).HasColumnName("Seronegativo_VIH");
            entity.Property(e => e.Sexo).HasMaxLength(1);
            entity.Property(e => e.SignosSintomas).HasColumnName("Signos_Sintomas");
            entity.Property(e => e.Srs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SRS");
            entity.Property(e => e.TallaPies).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TallaPulgadas).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Usuario)
                .HasMaxLength(100)
                .UseCollation("Modern_Spanish_CI_AS");
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

        modelBuilder.Entity<VwPrepPacientesGeneral>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Prep_Pacientes_General");

            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.Ars)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ARS");
            entity.Property(e => e.Centro)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CENTRO");
            entity.Property(e => e.ComoTeConsideras).HasColumnName("Como_te_consideras");
            entity.Property(e => e.FechaIngresoSai)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Ingreso_SAI");
            entity.Property(e => e.IdCentro).HasColumnName("ID_CENTRO");
            entity.Property(e => e.IdRegion)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ID_Region");
            entity.Property(e => e.MunicipioResidencia)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.NacionalidadMadre)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.Nombres).HasMaxLength(100);
            entity.Property(e => e.PacienteId).HasColumnName("Paciente_Id");
            entity.Property(e => e.Peso).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Provincia)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProvinciaResidencia)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Sexo).HasMaxLength(1);
            entity.Property(e => e.Srs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SRS");
            entity.Property(e => e.TallaPies).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TallaPulgadas).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Usuario)
                .HasMaxLength(100)
                .UseCollation("Modern_Spanish_CI_AS");
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

        modelBuilder.Entity<VwProvincia>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Provincias");

            entity.Property(e => e.IdProvincia)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_Provincia");
            entity.Property(e => e.IdProvinciaJce)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ID_Provincia_JCE");
            entity.Property(e => e.IdRegion)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ID_Region");
            entity.Property(e => e.Provincia)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwRptPacientesDetalle>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_RPT_PACIENTES_DETALLES");

            entity.Property(e => e.Ars)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ARS");
            entity.Property(e => e.CantParejasSexuales).HasColumnName("Cant_Parejas_Sexuales");
            entity.Property(e => e.DrogasIlicitas).HasColumnName("Drogas_Ilicitas");
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ESTATUS");
            entity.Property(e => e.FechaCreatinina)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("FECHA_Creatinina");
            entity.Property(e => e.FechaHemograma)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("FECHA_Hemograma");
            entity.Property(e => e.FechaIngresoSai)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Ingreso_SAI");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Nacimiento");
            entity.Property(e => e.FechaPruebaVih)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Prueba_VIH");
            entity.Property(e => e.FechaSeguimiento).HasColumnType("datetime");
            entity.Property(e => e.FechaUrea)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("FECHA_UREA");
            entity.Property(e => e.HbsAg).HasColumnName("HBsAg");
            entity.Property(e => e.HbsAgFecha)
                .HasColumnType("datetime")
                .HasColumnName("HBsAg_Fecha");
            entity.Property(e => e.HepatitisC).HasColumnName("Hepatitis_C");
            entity.Property(e => e.HepatitisCFecha)
                .HasColumnType("datetime")
                .HasColumnName("Hepatitis_C_Fecha");
            entity.Property(e => e.IdRegion)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ID_Region");
            entity.Property(e => e.MesesPrescripcion).HasColumnName("Meses_prescripcion");
            entity.Property(e => e.MunicipioResidencia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Municipio_Residencia");
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("NACIONALIDAD");
            entity.Property(e => e.NombreCentro)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Provincia)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProvinciaResidencia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("provincia_Residencia");
            entity.Property(e => e.ResultadoCreatinina).HasColumnName("Resultado_Creatinina");
            entity.Property(e => e.ResultadoPruebaVih).HasColumnName("Resultado_Prueba_VIH");
            entity.Property(e => e.SecrecionUretral).HasColumnName("Secrecion_uretral");
            entity.Property(e => e.SecrecionVaginal).HasColumnName("Secrecion_vaginal");
            entity.Property(e => e.Sexo).HasMaxLength(1);
            entity.Property(e => e.SexoConVihpositivo).HasColumnName("SexoConVIHPositivo");
            entity.Property(e => e.SexoPorBienes).HasColumnName("Sexo_Por_Bienes");
            entity.Property(e => e.SexoPorBienesPareja).HasColumnName("Sexo_Por_Bienes_Pareja");
            entity.Property(e => e.SexoSinProteccion).HasColumnName("Sexo_Sin_Proteccion");
            entity.Property(e => e.SifilisFecha)
                .HasColumnType("datetime")
                .HasColumnName("Sifilis_Fecha");
            entity.Property(e => e.Srs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SRS");
            entity.Property(e => e.Tarv)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("TARV");
            entity.Property(e => e.TieneDocumentos).HasColumnName("Tiene_documentos");
            entity.Property(e => e.TienesRelacionesCon).HasColumnName("Tienes_Relaciones_Con");
            entity.Property(e => e.TipoDocumento).HasColumnName("Tipo_Documento");
            entity.Property(e => e.Transf)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("TRANSF");
            entity.Property(e => e.UlceraGenital).HasColumnName("Ulcera_genital");
            entity.Property(e => e.Urea).HasColumnName("UREA");
            entity.Property(e => e.VerrugasGenitales).HasColumnName("Verrugas_genitales");
        });

        modelBuilder.Entity<VwRptPacientesTotale>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_RPT_PACIENTES_TOTALES");

            entity.Property(e => e.IdRegion)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ID_Region");
            entity.Property(e => e.Municipio)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PacientesAsegurados).HasColumnName("PACIENTES_Asegurados");
            entity.Property(e => e.PacientesDominicanos).HasColumnName("PACIENTES_Dominicanos");
            entity.Property(e => e.PacientesEmbarazadas).HasColumnName("PACIENTES_EMBARAZADAS");
            entity.Property(e => e.PacientesFemeninos).HasColumnName("PACIENTES_Femeninos");
            entity.Property(e => e.PacientesMasculinos).HasColumnName("PACIENTES_Masculinos");
            entity.Property(e => e.PacientesOtrasNacionalidades).HasColumnName("PACIENTES_Otras_Nacionalidades");
            entity.Property(e => e.PacientesSinDocumento).HasColumnName("PACIENTES_SIN_DOCUMENTO");
            entity.Property(e => e.Provincia)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ServicioSai).HasColumnName("Servicio_SAI");
            entity.Property(e => e.Srs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SRS");
        });

        modelBuilder.Entity<VwSirenpPaciente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Sirenp_Pacientes");

            entity.Property(e => e.CedPas)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ced_pas");
            entity.Property(e => e.PruebaFecha)
                .HasColumnType("date")
                .HasColumnName("PRUEBA_FECHA");
            entity.Property(e => e.ResultadoFinal).HasMaxLength(100);
        });

        modelBuilder.Entity<VwUsuariosEstablecimiento>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_UsuariosEstablecimientos");

            entity.Property(e => e.IdCentro).HasColumnName("ID_CENTRO");
            entity.Property(e => e.NombreCentro)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwUsuariosIntranet>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_usuarios_intranet");

            entity.Property(e => e.Activo)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.IdDeptoDepend)
                .HasMaxLength(15)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.Identificador)
                .HasMaxLength(10)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.NombreApellidos)
                .HasMaxLength(100)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.PasswordExpira)
                .HasMaxLength(1)
                .IsFixedLength()
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.PasswordExpiraFecha).HasColumnType("datetime");
            entity.Property(e => e.Usuario)
                .HasMaxLength(13)
                .UseCollation("Modern_Spanish_CI_AS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
