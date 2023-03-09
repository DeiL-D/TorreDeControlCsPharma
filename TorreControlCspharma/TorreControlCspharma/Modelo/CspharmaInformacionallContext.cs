using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TorreControlCspharma.Modelo;

public partial class CspharmaInformacionallContext : DbContext
{
    public CspharmaInformacionallContext()
    {
    }

    public CspharmaInformacionallContext(DbContextOptions<CspharmaInformacionallContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DlkCatAccEmpleado> DlkCatAccEmpleados { get; set; }

    public virtual DbSet<TdcCatEstadosDevolucionPedido> TdcCatEstadosDevolucionPedidos { get; set; }

    public virtual DbSet<TdcCatEstadosEnvioPedido> TdcCatEstadosEnvioPedidos { get; set; }

    public virtual DbSet<TdcCatEstadosPagoPedido> TdcCatEstadosPagoPedidos { get; set; }

    public virtual DbSet<TdcCatLineasDistribucion> TdcCatLineasDistribucions { get; set; }

    public virtual DbSet<TdcTchEstadoPedido> TdcTchEstadoPedidos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=cspharma_informacionall;User Id=postgres;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DlkCatAccEmpleado>(entity =>
        {
            entity.HasKey(e => e.CodEmpleado).HasName("dlk_cat_acc_empleados_pkey");

            entity.ToTable("dlk_cat_acc_empleados", "dlk_informacional");

            entity.Property(e => e.CodEmpleado)
                .HasColumnType("character varying")
                .HasColumnName("cod_empleado");
            entity.Property(e => e.ClaveEmpleado)
                .HasColumnType("character varying")
                .HasColumnName("clave_empleado");
            entity.Property(e => e.EmailEmpleado)
                .HasColumnType("character varying")
                .HasColumnName("email_empleado");
            entity.Property(e => e.IdEmpleado)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_empleado");
            entity.Property(e => e.MdDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUid)
                .HasColumnType("character varying")
                .HasColumnName("md_uid");
            entity.Property(e => e.NivelAcceso)
                .HasColumnType("character varying")
                .HasColumnName("nivel_acceso");
        });

        modelBuilder.Entity<TdcCatEstadosDevolucionPedido>(entity =>
        {
            entity.HasKey(e => e.CodEstadoDevolUcion).HasName("tdc_cat_estados_devolucion_pedido_pkey");

            entity.ToTable("tdc_cat_estados_devolucion_pedido", "dwh_torrecontrol");

            entity.Property(e => e.CodEstadoDevolUcion)
                .HasComment("Código que\nidentifica de forma\nunívoca el estado\nde devolución de\nun pedido")
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_devol ucion");
            entity.Property(e => e.DesEstadoDevolUcion)
                .HasComment("Descripción del\nestado de\ndevolución del\npedido")
                .HasColumnType("character varying")
                .HasColumnName("des_estado_devol ucion");
            entity.Property(e => e.IdDevolucion)
                .ValueGeneratedOnAdd()
                .HasComment("Identificador\nunívoco del\nestado de\ndevolución del\npedido en el")
                .HasColumnName("id_devolucion");
            entity.Property(e => e.MdDate)
                .HasComment("Fecha en la que\nse\ndefine el grupo de\ninserción.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasComment("Código de\nmetadato\nque indica el\ngrupo\nde inserción al\nque\npertenece el\nregistro.")
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
        });

        modelBuilder.Entity<TdcCatEstadosEnvioPedido>(entity =>
        {
            entity.HasKey(e => e.CodEstadoEnvio).HasName("tdc_cat_estados_envio_pedido_pkey");

            entity.ToTable("tdc_cat_estados_envio_pedido", "dwh_torrecontrol");

            entity.Property(e => e.CodEstadoEnvio)
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_envio");
            entity.Property(e => e.DesEstadoEnvio)
                .HasColumnType("character varying")
                .HasColumnName("des_estado_envio");
            entity.Property(e => e.IdEnvio)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_envio");
            entity.Property(e => e.MdDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
        });

        modelBuilder.Entity<TdcCatEstadosPagoPedido>(entity =>
        {
            entity.HasKey(e => e.CodEstadoPago).HasName("tdc_cat_estados_pago_pedido_pkey");

            entity.ToTable("tdc_cat_estados_pago_pedido", "dwh_torrecontrol");

            entity.Property(e => e.CodEstadoPago)
                .HasComment("Código que\nidentifica de forma\nunívoca el estado\nde pago de un\npedido")
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_pago");
            entity.Property(e => e.DesEstadoPago)
                .HasComment("Descripción del\nestado de pago\ndel pedido")
                .HasColumnType("character varying")
                .HasColumnName("des_estado_pago");
            entity.Property(e => e.IdPago)
                .ValueGeneratedOnAdd()
                .HasComment("Fecha en la que\nse\ndefine el grupo de\ninserción.")
                .HasColumnName("id_pago");
            entity.Property(e => e.MdDate)
                .HasComment("Fecha en la que\nse\ndefine el grupo de\ninserción.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasComment("Código de\nmetadato\nque indica el\ngrupo\nde inserción al\nque\npertenece el\nregistro.")
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
        });

        modelBuilder.Entity<TdcCatLineasDistribucion>(entity =>
        {
            entity.HasKey(e => e.CodLinea).HasName("tdc_cat_lineas_distribucion_pkey");

            entity.ToTable("tdc_cat_lineas_distribucion", "dwh_torrecontrol");

            entity.Property(e => e.CodLinea)
                .HasComment("Código que\nidentifica de forma\nunívoca la línea\nde distribución por\ncarretera que\nsigue el envío:\ncodprovincia-cod\nmunicipio-codbarri\no")
                .HasColumnType("character varying")
                .HasColumnName("cod_linea");
            entity.Property(e => e.CodBarrio)
                .HasComment("Código que\nidentifica de forma\nunívoca el barrio")
                .HasColumnType("character varying")
                .HasColumnName("cod_barrio");
            entity.Property(e => e.CodMunicipio)
                .HasComment("Código que\nidentifica de forma\nunívoca el\nmunicipio")
                .HasColumnType("character varying")
                .HasColumnName("cod_municipio");
            entity.Property(e => e.CodProvincia)
                .HasComment("Código que\nidentifica de forma\nunívoca a la\nprovincia")
                .HasColumnType("character varying")
                .HasColumnName("cod_provincia");
            entity.Property(e => e.IdLineasDistribucion)
                .ValueGeneratedOnAdd()
                .HasComment("Identificador\nunívoco de la\nlínea de\ndistribución en el\nsistema")
                .HasColumnName("id_lineas_distribucion");
            entity.Property(e => e.MdDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasComment("Código de\nmetadato\nque indica el\ngrupo\nde inserción al\nque\npertenece el\nregistro.")
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
        });

        modelBuilder.Entity<TdcTchEstadoPedido>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tdc_tch_estado_pedidos", "dwh_torrecontrol");

            entity.Property(e => e.CodEstadoDevolucion)
                .HasComment("Código que\nidentifica de forma\nunívoca el estado\nde devolución de\nun pedido")
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_devolucion");
            entity.Property(e => e.CodEstadoEnvio)
                .HasComment("Código que\nidentifica de forma\nunívoca el estado\nde envío de un\npedido")
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_envio");
            entity.Property(e => e.CodEstadoPago)
                .HasComment("Código que\nidentifica de forma\nunívoca el estado\nde pago de un\npedido")
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_pago");
            entity.Property(e => e.CodLinea)
                .HasComment("Código que\nidentifica de forma\nunívoca la línea\nde distribución por\ncarretera que\nsigue el envío:\ncodprovincia-cod\nmunicipio-codbarri\no")
                .HasColumnType("character varying")
                .HasColumnName("cod_linea");
            entity.Property(e => e.CodPedido)
                .HasComment("Código que\nidentifica de forma\nunívoca un\npedido. Se\nconstruye con:\nprovincia-codfarm\nacia-id")
                .HasColumnType("character varying")
                .HasColumnName("cod_pedido");
            entity.Property(e => e.IdPedido)
                .ValueGeneratedOnAdd()
                .HasComment("Identificador unívoco del pedido en el sistema")
                .HasColumnName("id_pedido");
            entity.Property(e => e.MdDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasComment("Código de metadatoque indica el grupo de inserción al que pertenece el registro.")
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");

            entity.HasOne(d => d.CodEstadoDevolucionNavigation).WithMany()
                .HasForeignKey(d => d.CodEstadoDevolucion)
                .HasConstraintName("devoluciones_pedidos_fk");

            entity.HasOne(d => d.CodEstadoEnvioNavigation).WithMany()
                .HasForeignKey(d => d.CodEstadoEnvio)
                .HasConstraintName("envios_pedidos_fk");

            entity.HasOne(d => d.CodEstadoPagoNavigation).WithMany()
                .HasForeignKey(d => d.CodEstadoPago)
                .HasConstraintName("pagos_pedidos_fk");

            entity.HasOne(d => d.CodLineaNavigation).WithMany()
                .HasForeignKey(d => d.CodLinea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("lineas_pedidos_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
