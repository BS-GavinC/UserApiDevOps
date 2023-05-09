using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public static class FakeDb
    {

        public static List<UserModel> Users = new List<UserModel>
        {
            new UserModel(1, "Jean", "Benguigui", "JB@jb.com", "$argon2i$v=19$m=16,t=2,p=1$RGV2T3BzMjAyMw$IOUuuYue1DMMuUA9RdeBDg", new DateTime(1995, 01,24), true),
            new UserModel(2, "Lucas", "Dupont", "lucas.dupont@email.com", "$argon2i$v=19$m=16,t=2,p=1$RGV2T3BzMjAyMA$KplUQg92VYRQtj5zvSw7CA", new DateTime(1992, 07, 14), false),
            new UserModel(3, "Alice", "Martin", "alice.martin@email.com", "$argon2i$v=19$m=16,t=2,p=1$RGV2T3BzMjAyMQ$5TM4rPrd/s9co7sDaT/iuA", new DateTime(1990, 02, 12), false),
            new UserModel(4, "Thomas", "Leroux", "thomas.leroux@email.com", "$argon2i$v=19$m=16,t=2,p=1$RGV2T3BzMjAyMg$FF65e+TqpXFttc/BenlMWg", new DateTime(1985, 11, 21), false),
            new UserModel(5, "Marie", "Garcia", "marie.garcia@email.com", "$argon2i$v=19$m=16,t=2,p=1$RGV2T3BzMjAyMg$FF65e+TqpXFttc/BenlMWg", new DateTime(1998, 03, 29), false),
            new UserModel(6, "Julien", "Lefebvre", "julien.lefebvre@email.com", "$argon2i$v=19$m=16,t=2,p=1$RGV2T3BzMjAyMg$FF65e+TqpXFttc/BenlMWg", new DateTime(1988, 05, 18), false),
            new UserModel(7, "Laura", "Moreau", "laura.moreau@email.com", "$argon2i$v=19$m=16,t=2,p=1$RGV2T3BzMjAyMg$FF65e+TqpXFttc/BenlMWg", new DateTime(1993, 09, 03), false),
            new UserModel(8, "Nicolas", "Dufour", "nicolas.dufour@email.com", "$argon2i$v=19$m=16,t=2,p=1$RGV2T3BzMjAyMg$FF65e+TqpXFttc/BenlMWg", new DateTime(1987, 12, 17), false),
            new UserModel(9, "Céline", "Renard", "celine.renard@email.com", "$argon2i$v=19$m=16,t=2,p=1$RGV2T3BzMjAyMg$FF65e+TqpXFttc/BenlMWg", new DateTime(1990, 04, 08), false),
            new UserModel(10, "Alexandre", "Roux", "alexandre.roux@email.com", "$argon2i$v=19$m=16,t=2,p=1$RGV2T3BzMjAyMg$FF65e+TqpXFttc/BenlMWg", new DateTime(1986, 06, 07), false),
            new UserModel(11, "Pauline", "Fontaine", "pauline.fontaine@email.com", "$argon2i$v=19$m=16,t=2,p=1$RGV2T3BzMjAyMg$FF65e+TqpXFttc/BenlMWg", new DateTime(1995, 08, 27), false),
            new UserModel(12, "Antoine", "Lecomte", "antoine.lecomte@email.com", "$argon2i$v=19$m=16,t=2,p=1$RGV2T3BzMjAyMg$FF65e+TqpXFttc/BenlMWg", new DateTime(1991, 10, 13), false),
            new UserModel(13, "Émilie", "Gauthier", "emilie.gauthier@email.com", "$argon2i$v=19$m=16,t=2,p=1$RGV2T3BzMjAyMg$FF65e+TqpXFttc/BenlMWg", new DateTime(1994, 02, 28), false),
            new UserModel(14, "Vincent", "Dumont", "vincent.dumont@email.com", "$argon2i$v=19$m=16,t=2,p=1$RGV2T3BzMjAyMg$FF65e+TqpXFttc/BenlMWg", new DateTime(1989, 06, 19), false),
            new UserModel(15, "Aurélie", "Rousseau", "aurelie.rousseau@email.com", "$argon2i$v=19$m=16,t=2,p=1$RGV2T3BzMjAyMg$FF65e+TqpXFttc/BenlMWg", new DateTime(1997, 09, 09), false),
            new UserModel(16, "Maxime", "Blanchard", "maxime.blanchard@email.com", "$argon2i$v=19$m=16,t=2,p=1$RGV2T3BzMjAyMg$FF65e+TqpXFttc/BenlMWg", new DateTime(1984, 01, 30), false),
            new UserModel(17, "Sophie", "Girard", "sophie.girard@email.com", "$argon2i$v=19$m=16,t=2,p=1$RGV2T3BzMjAyMg$FF65e+TqpXFttc/BenlMWg", new DateTime(1993, 03, 16), false),
            new UserModel(18, "Pierre", "Mercier", "pierre.mercier@email.com", "$argon2i$v=19$m=16,t=2,p=1$RGV2T3BzMjAyMg$FF65e+TqpXFttc/BenlMWg", new DateTime(1988, 05, 22), false),
            new UserModel(19, "Isabelle", "Delmas", "isabelle.delmas@email.com", "$argon2i$v=19$m=16,t=2,p=1$RGV2T3BzMjAyMg$FF65e+TqpXFttc/BenlMWg", new DateTime(1995, 10, 10), false),
            new UserModel(20, "Louis", "Berger", "louis.berger@email.com", "$argon2i$v=19$m=16,t=2,p=1$RGV2T3BzMjAyMg$FF65e+TqpXFttc/BenlMWg", new DateTime(1992, 12, 06), false)
        };

        public static int NewId { get; set; } = 21;
    }
}
