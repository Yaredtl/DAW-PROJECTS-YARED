﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AUT02_05.Migrations.Diccionario
{
    /// <inheritdoc />
    public partial class SeedingCSV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Frase",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fraesp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fraing = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EspengID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frase", x => x.id);
                    table.ForeignKey(
                        name: "FK_Frase_Espeng_EspengID",
                        column: x => x.EspengID,
                        principalTable: "Espeng",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Frase",
                columns: new[] { "id", "EspengID", "fraesp", "fraing" },
                values: new object[,]
                {
                    { 1, 19489, "\"Hicieron un zoom sobre la imagen para ver más detalles.\"", "\"They zoomed in on the image to see more details.\"" },
                    { 2, 19488, "\"El zoólogo estaba observando el comportamiento de los elefantes.\"", "\"The zoologist was observing the behavior of the elephants.\"" },
                    { 3, 19485, "\"Fuimos al zoo a ver a los leones y tigres.\"", "\"We went to the zoo to see the lions and tigers.\"" },
                    { 4, 19484, "\"El área zonal tiene acceso directo a la autopista.\"", "\"The zonal area has direct access to the highway.\"" },
                    { 5, 5344, "\"La cremallera de mi chaqueta está rota.\"", "\"The zipper on my jacket is broken.\"" },
                    { 6, 17156, "\"Sión es una ciudad mencionada en muchos textos bíblicos.\"", "\"Zion is a city mentioned in many biblical texts.\"" },
                    { 7, 3743, "\"El número cero es fundamental en matemáticas.\"", "\"The number zero is fundamental in mathematics.\"" },
                    { 8, 3626, "\"La cebra tiene rayas blancas y negras.\"", "\"The zebra has black and white stripes.\"" },
                    { 9, 7557, "\"Ella es una persona entusiasta que siempre apoya nuevos proyectos.\"", "\"She is a zealous person who always supports new projects.\"" },
                    { 10, 3650, "\"El celota defendía su creencia con gran fervor.\"", "\"The zealot defended his belief with great fervor.\"" },
                    { 11, 5856, "\"El defensor de los derechos humanos luchaba por la igualdad.\"", "\"The zealot for human rights fought for equality.\"" },
                    { 12, 3644, "\"El celo por su trabajo le permitió lograr grandes éxitos.\"", "\"His zeal for his work allowed him to achieve great successes.\"" },
                    { 13, 19474, "\"Me gusta zapear en las redes sociales para descubrir nuevas tendencias.\"", "\"I like to zap (to) on social media to discover new trends.\"" },
                    { 14, 8054, "\"El estilo estrafalario de su ropa siempre llamaba la atención.\"", "\"His zany style of clothing always attracted attention.\"" },
                    { 15, 19459, "\"Zagreb es la capital de Croacia.\"", "\"Zagreb is the capital of Croatia.\"" },
                    { 16, 19450, "\"Yugoslavia fue un país que existió en el sureste de Europa.\"", "\"Yugoslavia was a country that existed in Southeast Europe.\"" },
                    { 17, 19451, "\"El término yugoslavo se refiere a los pueblos de la antigua Yugoslavia.\"", "\"The term Yugoslav refers to the peoples of the former Yugoslavia.\"" },
                    { 18, 10645, "\"Su actitud juvenil era refrescante y llena de energía.\"", "\"His youthful attitude was refreshing and full of energy.\"" },
                    { 19, 10646, "\"La juventud tiene muchas ideas innovadoras que cambiarán el futuro.\"", "\"Youth has many innovative ideas that will change the future.\"" },
                    { 20, 17422, "\"¿Dónde está tu libro?\"", "\"Where is your book?\"" },
                    { 21, 19498, "\"Zúrich es conocida por su alto nivel de calidad de vida y su estabilidad económica.\"", "\"Zurich is known for its high quality of life and economic stability.\"" },
                    { 22, 19489, "\"Usé el zoom para poder ver los detalles del cuadro con más claridad.\"", "\"I used the zoom to get a clearer view of the details in the painting.\"" },
                    { 23, 19486, "\"En la universidad", " estudié zoología porque siempre me han fascinado los animales.\"" },
                    { 24, 19488, "\"El zoólogo recogió datos durante su investigación sobre los gorilas.\"", "\"The zoologist gathered data during his research on gorillas.\"" },
                    { 25, 19487, "\"El zoológico tiene una nueva exposición de aves exóticas.\"", "\"The zoological park has a new exhibit of exotic birds.\"" },
                    { 26, 19485, "\"Los niños se divierten mucho viendo a los animales en el zoo.\"", "\"The kids have a lot of fun watching the animals at the zoo.\"" },
                    { 27, 19483, "\"La zona residencial está muy tranquila", " ideal para vivir.\"" },
                    { 28, 19484, "\"La zona de estacionamiento es exclusiva para empleados.\"", "\"The parking zone is reserved for employees.\"" },
                    { 29, 19481, "\"El zodíaco chino se basa en un ciclo de 12 años.\"", "\"The Chinese zodiac is based on a 12-year cycle.\"" },
                    { 30, 5344, "\"La cremallera de mi mochila se rompió cuando la cerré demasiado rápido.\"", "\"The zipper on my backpack broke when I zipped it up too quickly.\"" },
                    { 31, 17001, "\"Escuché un silbido extraño que provenía del pasillo.\"", "\"I heard a strange whistle coming from the hallway.\"" },
                    { 32, 17156, "\"Sión fue un símbolo importante en las escrituras religiosas.\"", "\"Zion was an important symbol in religious scriptures.\"" },
                    { 33, 1241, "\"Esa película tiene un estilo animado que atrae tanto a niños como a adultos.\"", "\"That movie has a zestful style that appeals to both children and adults.\"" },
                    { 34, 3743, "\"El número cero tiene un valor único en matemáticas y ciencias.\"", "\"The number zero has a unique value in mathematics and science.\"" },
                    { 35, 3670, "\"Alcanzaron el cenit de su éxito cuando su álbum llegó al número uno.\"", "\"They reached the zenith of their success when their album hit number one.\"" },
                    { 36, 3626, "\"En el safari", " vimos una cebra cruzando la carretera.\"" },
                    { 37, 3649, "\"Es muy celoso con sus pertenencias", " no le gusta compartir.\"" },
                    { 38, 7557, "\"Es una persona tan entusiasta que contagia su energía a los demás.\"", "\"She is such a zealous person that she spreads her energy to others.\"" },
                    { 39, 8282, "\"El fanatismo religioso puede ser peligroso si se lleva al extremo.\"", "\"Religious zealotry can be dangerous if taken to the extreme.\"" },
                    { 40, 3650, "\"El celota estaba dispuesto a dar su vida por su causa.\"", "\"The zealot was willing to give his life for his cause.\"" },
                    { 41, 5856, "\"El defensor de los derechos civiles luchó por la igualdad en la sociedad.\"", "\"The zealot for civil rights fought for equality in society.\"" },
                    { 42, 3644, "\"Su celo por la excelencia lo ha llevado a ser un líder en su campo.\"", "\"His zeal for excellence has made him a leader in his field.\"" },
                    { 43, 19474, "\"Me encanta zapear entre canales hasta encontrar algo interesante.\"", "\"I love zapping between channels until I find something interesting.\"" },
                    { 44, 8054, "\"Su comportamiento estrafalario lo hizo famoso en la escuela.\"", "\"His zany behavior made him famous at school.\"" },
                    { 45, 19459, "\"Zagreb es una ciudad vibrante con mucha historia y cultura.\"", "\"Zagreb is a vibrant city with a lot of history and culture.\"" },
                    { 46, 19450, "\"Yugoslavia fue un país que dejó una huella importante en la historia de Europa.\"", "\"Yugoslavia was a country that left a significant mark on European history.\"" },
                    { 47, 19451, "\"La comida yugoslava es muy variada y deliciosa", " con influencias balcánicas.\"" },
                    { 48, 10645, "\"Su personalidad juvenil siempre traía una energía renovadora al grupo.\"", "\"His youthful personality always brought a refreshing energy to the group.\"" },
                    { 49, 10646, "\"La juventud de hoy está más conectada globalmente que nunca antes.\"", "\"Today's youth is more globally connected than ever before.\"" },
                    { 50, 17422, "\"Tu respuesta no me parece correcta", " ¿puedes explicar más?\"" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Frase_EspengID",
                table: "Frase",
                column: "EspengID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Frase");
        }
    }
}
