use DB_Bazar

insert into Category(Id, Name)
VALUES
('828888cc-9ba5-4a76-b1e9-6527f3a38fe8', 'Games e consoles'),
('ffe59451-edd6-4264-8c06-e72e8e6fc2fc', 'Eletrodomésticos'),
('7a8a34af-a3f2-4b6f-9721-90d2ba245115', 'Computadores e informatica')

INSERT INTO Product (ID, Name, Price, Description, CategoryID, Images)
VALUES
    ('5cf65ad6-bc9d-44c4-84a2-b9026f71cc12', 'Playstation', 5.000, 'play que caiu do caminhão', '828888cc-9ba5-4a76-b1e9-6527f3a38fe8' , 'mopa.png'),
    ('cc319c02-1343-4bed-9791-2df8758e146f', 'Xbox one S', 1.000, 'Bom demais slk apenas uma unidade vai acabar em', '828888cc-9ba5-4a76-b1e9-6527f3a38fe8' , 'mopa.png'),
    ('5cf65ad6-bc9d-44c4-84a2-b9026f71cc13', 'Monitor Full hd 144hz', 2.000, 'monitor que caiu do caminhão', '828888cc-9ba5-4a76-b1e9-6527f3a38fe8' , 'mopa.png'),
    ('cc319c02-1343-4bed-9791-2df8758e1464', 'PlayStation 1', 1.000, 'Bom demais slk apenas uma unidade vai acabar em', '828888cc-9ba5-4a76-b1e9-6527f3a38fe8' , 'mopa.png'),
    ('5cf65ad6-bc9d-44c4-84a2-b9026f71cc15', 'Playstation 2', 3.000, 'play que caiu do caminhão', '828888cc-9ba5-4a76-b1e9-6527f3a38fe8' , 'mopa.png'),
    ('cc319c02-1343-4bed-9791-2df8758e1466', 'Playstation 5', 4.000, 'Bom demais slk apenas uma unidade vai acabar em', '828888cc-9ba5-4a76-b1e9-6527f3a38fe8' , 'mopa.png'),
    ('5cf65ad6-bc9d-44c4-84a2-b9026f71cc17', 'Polystation', 0.500, 'play que caiu do caminhão', '828888cc-9ba5-4a76-b1e9-6527f3a38fe8' , 'mopa.png'),
    ('cc319c02-1343-4bed-9791-2df8758e1468', 'Xbox one X', 5.000, 'Bom demais slk apenas uma unidade vai acabar em', '828888cc-9ba5-4a76-b1e9-6527f3a38fe8' , 'mopa.png'),
    
    ('9bb36511-f1a7-4342-bbf0-04e34260ced1', 'Geladeira de 10k do lucas', 10.000, 'Geladeira que supostamente vale isso ai', 'ffe59451-edd6-4264-8c06-e72e8e6fc2fc' , 'mopa.png'),
    ('418e4901-b0dc-4c49-b63c-055bc3a937e2', 'Microondas', 350, 'Bom demais, a experiencia do uso dignifica o preço', 'ffe59451-edd6-4264-8c06-e72e8e6fc2fc' , 'mopa.png'),
    ('9bb36511-f1a7-4342-bbf0-04e34260ced3', 'Filtro de água', 80.000, 'Filtro que supostamente vale isso ai', 'ffe59451-edd6-4264-8c06-e72e8e6fc2fc' , 'mopa.png'),
    ('418e4901-b0dc-4c49-b63c-055bc3a937e4', 'Fogão', 350, 'Bom demais, a experiencia do uso dignifica o preço', 'ffe59451-edd6-4264-8c06-e72e8e6fc2fc' , 'mopa.png'),
    ('9bb36511-f1a7-4342-bbf0-04e34260ced5', 'Aquecedor', 11.000, 'Aquecedor que supostamente vale isso ai', 'ffe59451-edd6-4264-8c06-e72e8e6fc2fc' , 'mopa.png'),
    ('418e4901-b0dc-4c49-b63c-055bc3a937e6', 'Air fryer', 650, 'Bom demais, a experiencia do uso dignifica o preço', 'ffe59451-edd6-4264-8c06-e72e8e6fc2fc' , 'mopa.png'),
    
    ('51251360-7590-4741-92bf-5cdb71beec31', 'Desktop do lucas', 8.000, 'Vendemos um pc gamer mas sem placa de video pq a plca é cara demais', '7a8a34af-a3f2-4b6f-9721-90d2ba245115' , 'mopa.png'),
    ('772c605e-4e6e-4180-bf9d-4dc36a4b6f42', 'Mouse', 1.000, 'mouse bom tbm faz muita coisa alem do click', '7a8a34af-a3f2-4b6f-9721-90d2ba245115' , 'mopa.png'),
    ('51251360-7590-4741-92bf-5cdb71beec33', 'Desktop do Felipe Indio', 8.000, 'Vendemos um pc gamer mas sem placa de video pq a plca é cara demais', '7a8a34af-a3f2-4b6f-9721-90d2ba245115' , 'mopa.png'),
    ('772c605e-4e6e-4180-bf9d-4dc36a4b6f44', 'Mouse câmbio de veiculo do Felipe Indio', 2.000, 'mouse improvisado retirado de veiculo', '7a8a34af-a3f2-4b6f-9721-90d2ba245115' , 'mopa.png'),
    ('51251360-7590-4741-92bf-5cdb71beec35', 'Sensor de animais selvagens', 8.000, 'Parelheiros irmão, confia vai precisar', '7a8a34af-a3f2-4b6f-9721-90d2ba245115' , 'mopa.png'),
    ('772c605e-4e6e-4180-bf9d-4dc36a4b6f46', 'Espelho', 100, 'Enganaram um indio com isso dizendo ser um portal tecnologico', '7a8a34af-a3f2-4b6f-9721-90d2ba245115' , 'mopa.png')
    