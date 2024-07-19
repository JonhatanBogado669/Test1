-- Creación de la tabla tipo_combus
CREATE TABLE tipo_combus (
    idtipo_combus INTEGER PRIMARY KEY AUTOINCREMENT,
    descripcion VARCHAR(45)
);

-- Creación de la tabla vehiculo
CREATE TABLE vehiculo (
    idvehiculo INTEGER PRIMARY KEY AUTOINCREMENT,
    descripcion VARCHAR(45),
    chapa VARCHAR(45),
    idtipo_combus INTEGER,
    FOREIGN KEY(idtipo_combus) REFERENCES tipo_combus(idtipo_combus)
);

-- Creación de la tabla plan_combus
CREATE TABLE plan_combus (
    idplan_combus INTEGER PRIMARY KEY AUTOINCREMENT,
    periodo VARCHAR(45),
    idvehiculo INTEGER,
    fecha VARCHAR(45),
    ci VARCHAR(45),
    nombre VARCHAR(45),
    lugar_sal VARCHAR(45),
    km_salida INTEGER,
    lugar_dest VARCHAR(45),
    km_llegada INTEGER,
    km_recorrido INTEGER,
    motivo VARCHAR(45),
    lts_carg INTEGER,
    nro_fact VARCHAR(45),
    imp_total INTEGER,
    FOREIGN KEY(idvehiculo) REFERENCES vehiculo(idvehiculo)
);
-- Creación de la tabla mes
CREATE TABLE mes (
    idmes INTEGER PRIMARY KEY AUTOINCREMENT,
    descripcion VARCHAR(24)
);

-- Inserción de datos en la tabla mes
INSERT INTO mes (descripcion) VALUES ('Enero');
INSERT INTO mes (descripcion) VALUES ('Febrero');
INSERT INTO mes (descripcion) VALUES ('Marzo');
INSERT INTO mes (descripcion) VALUES ('Abril');
INSERT INTO mes (descripcion) VALUES ('Mayo');
INSERT INTO mes (descripcion) VALUES ('Junio');
INSERT INTO mes (descripcion) VALUES ('Julio');
INSERT INTO mes (descripcion) VALUES ('Agosto');
INSERT INTO mes (descripcion) VALUES ('Septiembre');
INSERT INTO mes (descripcion) VALUES ('Octubre');
INSERT INTO mes (descripcion) VALUES ('Noviembre');
INSERT INTO mes (descripcion) VALUES ('Diciembre');
CREATE TABLE serv1040 (
    idserv1040 INTEGER PRIMARY KEY AUTOINCREMENT,
    cant1040 INTEGER,
    horaserv INTEGER,
    estructural INTEGER,
    vehicular INTEGER,
    basural INTEGER,
    forestal INTEGER,
    pastizal INTEGER,
    desconocida INTEGER,
    premeditada INTEGER,
    accidental INTEGER,
    corto INTEGER,
    findelimpieza INTEGER,
    principio INTEGER,
    pequena INTEGER,
    mediana INTEGER,
    grande INTEGER,
    emergral INTEGER,
    agua INTEGER,
    pqsco2 INTEGER,
    combustible INTEGER,
    bombero INTEGER,
    tiempototal INTEGER,
    ileso INTEGER,
    herido INTEGER,
    fallecido INTEGER,
    rescate INTEGER,
    totalkm INTEGER,
    nomina VARCHAR(45)
);
CREATE TABLE serv1041 (
    idserv1041 INTEGER PRIMARY KEY AUTOINCREMENT,
    cant1041 INTEGER,
    horaserv INTEGER,
    arrollamiento INTEGER,
    choque INTEGER,
    vuelco INTEGER,
    caida INTEGER,
    aeronave INTEGER,
    peaton VARCHAR(5),
    moto VARCHAR(5),
    vehliviano VARCHAR(5),
    vehpesado VARCHAR(5),
    bus VARCHAR(5),
    danomat VARCHAR(5),
    conherido VARCHAR(5),
    conatrap VARCHAR(5),
    coninc VARCHAR(5),
    matpel VARCHAR(5),
    cintcond VARCHAR(5),
    cintacomp VARCHAR(5),
    cascocond VARCHAR(5),
    cascoacomp VARCHAR(5),
    ileso INTEGER,
    herido INTEGER,
    fallecido INTEGER,
    rescate INTEGER,
    combustible INTEGER,
    bombero INTEGER,
    kmrecorrido INTEGER,
    tiempototal INTEGER,
    nomina VARCHAR(45)
);
CREATE TABLE serv1043 (
    idserv1043 INTEGER PRIMARY KEY AUTOINCREMENT,
    cant1043 INTEGER,
    horaserv INTEGER,
    rescate INTEGER,
    recuperacion INTEGER,
    aniali INTEGER,
    cobertura INTEGER,
    curso INTEGER,
    transporte INTEGER,
    vivienda INTEGER,
    profundidad INTEGER,
    altura INTEGER,
    derrumbe INTEGER,
    naufragio INTEGER,
    bomba INTEGER,
    suicidio INTEGER,
    ileso INTEGER,
    herido INTEGER,
    fallecido INTEGER,
    combustible INTEGER,
    nomina VARCHAR(45)
);
CREATE TABLE informe (
    idinforme INTEGER PRIMARY KEY AUTOINCREMENT,
    fechaenv VARCHAR(10),
    hora VARCHAR(20),
    mes INTEGER,
    anho INTEGER,
    cantcia_est INTEGER,
    autor VARCHAR(45),
    telefono VARCHAR(45),
    lugar VARCHAR(45),
    fax VARCHAR(45),
    fechacierre VARCHAR(45),
    cantserv INTEGER,
    idserv1040 INTEGER,
    idserv1041 INTEGER,
    idserv1043 INTEGER,
    FOREIGN KEY(mes) REFERENCES mes(idmes) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY(idserv1040) REFERENCES serv1040(idserv1040) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY(idserv1041) REFERENCES serv1041(idserv1041) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY(idserv1043) REFERENCES serv1043(idserv1043) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE users (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    role VARCHAR(50) NOT NULL,
    CI INTEGER NOT NULL,
    correo VARCHAR(100) NOT NULL,
    phone VARCHAR(20)
);
CREATE TABLE password_reset (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    username VARCHAR(50) NOT NULL,
    reset_code VARCHAR(50) NOT NULL,
    FOREIGN KEY (username) REFERENCES users(username)
);
INSERT INTO tipo_combus(descripcion) VALUES ('diesel');
INSERT INTO tipo_combus(descripcion) VALUES ('nafta');
INSERT INTO users(username, password, role, CI, correo, phone) VALUES ('Jonhy', 'elmaspija', 'Admin', 5358270, 'megaxonx@gmail.com', '0984354294');
INSERT INTO users(username, password, role, CI, correo, phone) VALUES ('Joel', 'elmaspijita', 'Usuario', 5334522, 'joelnomas@gmail.com', '0982786766');
