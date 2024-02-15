﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TetePizza.Data;

#nullable disable

namespace TetePizza.Data.Migrations
{
    [DbContext(typeof(TetePizzaAppContext))]
    partial class TetePizzaAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TetePizza.Model.Ingredientes", b =>
                {
                    b.Property<int>("IdIngredient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdIngredient"));

                    b.Property<string>("Calories")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpiryDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsGlutenFree")
                        .HasColumnType("bit");

                    b.Property<string>("NameIngredient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NutritionalInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdIngredient");

                    b.HasIndex("PizzaId");

                    b.ToTable("Ingredientes");

                    b.HasData(
                        new
                        {
                            IdIngredient = 1,
                            Calories = "Cada Tomate contiene dos 22 calorías.",
                            ExpiryDate = "2024-02-20",
                            IsGlutenFree = true,
                            NameIngredient = "Tomate",
                            NutritionalInfo = "Consumir tomates es beneficioso para la salud debido a la amplia variedad de nutrientes y compuestos bioactivos que ofrecen.",
                            Origin = "Andalucía",
                            PizzaId = 1,
                            Price = 0.22m,
                            Quantity = 2,
                            Type = "Fruta"
                        },
                        new
                        {
                            IdIngredient = 2,
                            Calories = "Aproximadamente 200 calorías por cada 100 gramos de prosciutto.",
                            ExpiryDate = "2024-02-22",
                            IsGlutenFree = false,
                            NameIngredient = "Prosciutto",
                            NutritionalInfo = "Rico en grasas saludables y proteínas.",
                            Origin = "Italia",
                            PizzaId = 1,
                            Price = 1.3m,
                            Quantity = 3,
                            Type = "Carne"
                        },
                        new
                        {
                            IdIngredient = 3,
                            Calories = "Aproximadamente 110 calorías por cada 28 gramos de queso Parmesano.",
                            ExpiryDate = "2024-02-25",
                            IsGlutenFree = true,
                            NameIngredient = "Queso Parmesano",
                            NutritionalInfo = "Alto contenido de calcio y proteínas.",
                            Origin = "Italia",
                            PizzaId = 1,
                            Price = 2.5m,
                            Quantity = 4,
                            Type = "Lácteo"
                        },
                        new
                        {
                            IdIngredient = 4,
                            Calories = "No tiene calorías.",
                            ExpiryDate = "2024-03-01",
                            IsGlutenFree = true,
                            NameIngredient = "Aceite de Oliva",
                            NutritionalInfo = "Rico en grasas saludables.",
                            Origin = "Región Mediterránea",
                            PizzaId = 1,
                            Price = 3.0m,
                            Quantity = 1,
                            Type = "Condimento"
                        },
                        new
                        {
                            IdIngredient = 5,
                            Calories = "Cada tomate contiene aproximadamente 22 calorías.",
                            ExpiryDate = "2024-02-20",
                            IsGlutenFree = true,
                            NameIngredient = "Tomate",
                            NutritionalInfo = "Beneficioso para la salud debido a la variedad de nutrientes y compuestos bioactivos que ofrece.",
                            Origin = "Andalucía",
                            PizzaId = 2,
                            Price = 0.22m,
                            Quantity = 2,
                            Type = "Fruta"
                        },
                        new
                        {
                            IdIngredient = 6,
                            Calories = "Aproximadamente 7 calorías por cada taza de espinacas.",
                            ExpiryDate = "2024-02-18",
                            IsGlutenFree = true,
                            NameIngredient = "Espinaca",
                            NutritionalInfo = "Rica en vitaminas y minerales, baja en calorías.",
                            Origin = "Local",
                            PizzaId = 2,
                            Price = 0.3m,
                            Quantity = 1,
                            Type = "Vegetal"
                        },
                        new
                        {
                            IdIngredient = 7,
                            Calories = "Aproximadamente 11 calorías por cada 100 gramos de champiñones.",
                            ExpiryDate = "2024-02-15",
                            IsGlutenFree = true,
                            NameIngredient = "Champiñones",
                            NutritionalInfo = "Buena fuente de proteínas, vitaminas y minerales.",
                            Origin = "Cultivados",
                            PizzaId = 2,
                            Price = 0.25m,
                            Quantity = 2,
                            Type = "Hongos"
                        },
                        new
                        {
                            IdIngredient = 8,
                            Calories = "Cada Tomate contiene dos 22 calorías.",
                            ExpiryDate = "2024-02-20",
                            IsGlutenFree = true,
                            NameIngredient = "Tomate",
                            NutritionalInfo = "Consumir tomates es beneficioso para la salud debido a la amplia variedad de nutrientes y compuestos bioactivos que ofrecen.",
                            Origin = "Andalucía",
                            PizzaId = 3,
                            Price = 0.22m,
                            Quantity = 2,
                            Type = "Fruta"
                        },
                        new
                        {
                            IdIngredient = 9,
                            Calories = "Aproximadamente 250 calorías por cada 100 gramos de pepperoni.",
                            ExpiryDate = "2024-02-22",
                            IsGlutenFree = false,
                            NameIngredient = "Pepperoni",
                            NutritionalInfo = "Rico en grasas y proteínas, pero consumir con moderación debido a su contenido calórico.",
                            Origin = "Estados Unidos",
                            PizzaId = 3,
                            Price = 1.5m,
                            Quantity = 3,
                            Type = "Carne"
                        },
                        new
                        {
                            IdIngredient = 10,
                            Calories = "Aporta insignificantes calorías.",
                            ExpiryDate = "2024-02-10",
                            IsGlutenFree = true,
                            NameIngredient = "Oregano",
                            NutritionalInfo = "Aporta sabor y aroma a la pizza, sin calorías significativas.",
                            Origin = "Mediterráneo",
                            PizzaId = 3,
                            Price = 0.1m,
                            Quantity = 1,
                            Type = "Hierba"
                        },
                        new
                        {
                            IdIngredient = 11,
                            Calories = "Cada Tomate contiene dos 22 calorías.",
                            ExpiryDate = "2024-02-20",
                            IsGlutenFree = true,
                            NameIngredient = "Tomate",
                            NutritionalInfo = "Consumir tomates es beneficioso para la salud debido a la amplia variedad de nutrientes y compuestos bioactivos que ofrecen.",
                            Origin = "Andalucía",
                            PizzaId = 4,
                            Price = 0.22m,
                            Quantity = 2,
                            Type = "Fruta"
                        },
                        new
                        {
                            IdIngredient = 12,
                            Calories = "Aproximadamente 80 calorías por cada 28 gramos de queso mozzarella.",
                            ExpiryDate = "2024-02-25",
                            IsGlutenFree = true,
                            NameIngredient = "Queso Mozzarella",
                            NutritionalInfo = "Bajo contenido de grasa y alto contenido de proteínas y calcio.",
                            Origin = "Italia",
                            PizzaId = 4,
                            Price = 2.0m,
                            Quantity = 3,
                            Type = "Lácteo"
                        },
                        new
                        {
                            IdIngredient = 13,
                            Calories = "Aproximadamente 110 calorías por cada 28 gramos de queso cheddar.",
                            ExpiryDate = "2024-02-25",
                            IsGlutenFree = true,
                            NameIngredient = "Queso Cheddar",
                            NutritionalInfo = "Sabor fuerte y color naranja distintivo.",
                            Origin = "Inglaterra",
                            PizzaId = 4,
                            Price = 1.5m,
                            Quantity = 2,
                            Type = "Lácteo"
                        },
                        new
                        {
                            IdIngredient = 14,
                            Calories = "Aproximadamente 101 calorías por cada 28 gramos de queso Gouda.",
                            ExpiryDate = "2024-02-25",
                            IsGlutenFree = true,
                            NameIngredient = "Queso Gouda",
                            NutritionalInfo = "Sabor suave y cremoso.",
                            Origin = "Países Bajos",
                            PizzaId = 4,
                            Price = 1.8m,
                            Quantity = 2,
                            Type = "Lácteo"
                        },
                        new
                        {
                            IdIngredient = 15,
                            Calories = "Aproximadamente 95 calorías por cada 28 gramos de queso Brie.",
                            ExpiryDate = "2024-02-25",
                            IsGlutenFree = true,
                            NameIngredient = "Queso Brie",
                            NutritionalInfo = "Textura suave y sabor a nuez.",
                            Origin = "Francia",
                            PizzaId = 4,
                            Price = 2.2m,
                            Quantity = 2,
                            Type = "Lácteo"
                        },
                        new
                        {
                            IdIngredient = 16,
                            Calories = "Aproximadamente 66 calorías por cada 28 gramos de queso Roquefort.",
                            ExpiryDate = "2024-02-25",
                            IsGlutenFree = true,
                            NameIngredient = "Queso Roquefort",
                            NutritionalInfo = "Sabor fuerte y textura desmenuzable.",
                            Origin = "Francia",
                            PizzaId = 4,
                            Price = 3.5m,
                            Quantity = 2,
                            Type = "Lácteo"
                        },
                        new
                        {
                            IdIngredient = 17,
                            Calories = "Aproximadamente 117 calorías por cada 28 gramos de queso Gruyere.",
                            ExpiryDate = "2024-02-25",
                            IsGlutenFree = true,
                            NameIngredient = "Queso Gruyere",
                            NutritionalInfo = "Sabor a nuez y textura cremosa.",
                            Origin = "Suiza",
                            PizzaId = 4,
                            Price = 2.6m,
                            Quantity = 2,
                            Type = "Lácteo"
                        },
                        new
                        {
                            IdIngredient = 18,
                            Calories = "Aproximadamente 98 calorías por cada 28 gramos de queso Emmental.",
                            ExpiryDate = "2024-02-25",
                            IsGlutenFree = true,
                            NameIngredient = "Queso Emmental",
                            NutritionalInfo = "Sabor suave y textura elástica.",
                            Origin = "Suiza",
                            PizzaId = 4,
                            Price = 2.3m,
                            Quantity = 2,
                            Type = "Lácteo"
                        });
                });

            modelBuilder.Entity("TetePizza.Model.Pedidos", b =>
                {
                    b.Property<int>("IdOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOrder"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Usuario")
                        .HasColumnType("int");

                    b.HasKey("IdOrder");

                    b.HasIndex("Usuario");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("TetePizza.Model.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PedidosIdOrder")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PedidosIdOrder");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Classic Italian",
                            Price = 7.02m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Vegetariana",
                            Price = 6.77m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Pepperoni",
                            Price = 9.12m
                        },
                        new
                        {
                            Id = 4,
                            Name = "8 Quesos",
                            Price = 10.50m
                        });
                });

            modelBuilder.Entity("TetePizza.Model.Usuario", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"));

                    b.Property<string>("AdressUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUser");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("TetePizza.Model.Ingredientes", b =>
                {
                    b.HasOne("TetePizza.Model.Pizza", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TetePizza.Model.Pedidos", b =>
                {
                    b.HasOne("TetePizza.Model.Usuario", "User")
                        .WithMany()
                        .HasForeignKey("Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TetePizza.Model.Pizza", b =>
                {
                    b.HasOne("TetePizza.Model.Pedidos", null)
                        .WithMany("Pizzas")
                        .HasForeignKey("PedidosIdOrder");
                });

            modelBuilder.Entity("TetePizza.Model.Pedidos", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("TetePizza.Model.Pizza", b =>
                {
                    b.Navigation("Ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}
