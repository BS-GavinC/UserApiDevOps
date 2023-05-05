﻿using Domain.Models;
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
            new UserModel("Jean", "Benguigui", "JB@jb.com", "Test123=", new DateTime(1995, 01,24)),
            new UserModel("Lucas", "Dupont", "lucas.dupont@email.com", "Password123=", new DateTime(1992, 07, 14)),
            new UserModel("Alice", "Martin", "alice.martin@email.com", "MySecurePwd123=", new DateTime(1990, 02, 12)),
            new UserModel("Thomas", "Leroux", "thomas.leroux@email.com", "SuperPassword123=", new DateTime(1985, 11, 21)),
            new UserModel("Marie", "Garcia", "marie.garcia@email.com", "MyPassword123=", new DateTime(1998, 03, 29)),
            new UserModel("Julien", "Lefebvre", "julien.lefebvre@email.com", "MyPwd123=", new DateTime(1988, 05, 18)),
            new UserModel("Laura", "Moreau", "laura.moreau@email.com", "SecurePassword123=", new DateTime(1993, 09, 03)),
            new UserModel("Nicolas", "Dufour", "nicolas.dufour@email.com", "MySecurePwd123=", new DateTime(1987, 12, 17)),
            new UserModel("Céline", "Renard", "celine.renard@email.com", "Test123=", new DateTime(1990, 04, 08)),
            new UserModel("Alexandre", "Roux", "alexandre.roux@email.com", "MyPassword123=", new DateTime(1986, 06, 07)),
            new UserModel("Pauline", "Fontaine", "pauline.fontaine@email.com", "SuperSecurePwd123=", new DateTime(1995, 08, 27)),
            new UserModel("Antoine", "Lecomte", "antoine.lecomte@email.com", "MyPwd123=", new DateTime(1991, 10, 13)),
            new UserModel("Émilie", "Gauthier", "emilie.gauthier@email.com", "SecurePassword123=", new DateTime(1994, 02, 28)),
            new UserModel("Vincent", "Dumont", "vincent.dumont@email.com", "MySecurePwd123=", new DateTime(1989, 06, 19)),
            new UserModel("Aurélie", "Rousseau", "aurelie.rousseau@email.com", "Test123=", new DateTime(1997, 09, 09)),
            new UserModel("Maxime", "Blanchard", "maxime.blanchard@email.com", "MyPassword123=", new DateTime(1984, 01, 30)),
            new UserModel("Sophie", "Girard", "sophie.girard@email.com", "SuperSecurePwd123=", new DateTime(1993, 03, 16)),
            new UserModel("Pierre", "Mercier", "pierre.mercier@email.com", "MyPwd123=", new DateTime(1988, 05, 22)),
            new UserModel("Isabelle", "Delmas", "isabelle.delmas@email.com", "SecurePassword123=", new DateTime(1995, 10, 10)),
            new UserModel("Louis", "Berger", "louis.berger@email.com", "MySecurePwd123=", new DateTime(1992, 12, 06))
        };


    }
}
