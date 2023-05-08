
DELETE FROM [UserApp];

SET IDENTITY_INSERT [UserApp] ON;  

INSERT [UserApp] (User_Id, Firstname, Lastname, Birthdate, Email, Password_Hash)
 VALUES (1, 'Della', 'Duck', '1988-02-06', 'della.duck@gmail.com', '$argon2i$v=19$m=16,t=2,p=1$RGV2T3BzMjAyMw$IOUuuYue1DMMuUA9RdeBDg'),
		(2, 'Zaza', 'Vanderquack', '2001-11-11', 'zaza@outlook.com', '$argon2i$v=19$m=16,t=2,p=1$RGV2T3BzMjAyMg$FF65e+TqpXFttc/BenlMWg');

SET IDENTITY_INSERT [UserApp] OFF;  


