CREATE DATABASE IF NOT EXISTS BankingApp
default character set utf8mb4
default collate utf8mb4_general_ci;

USE BankingApp;

-- Tabela de Usuários
CREATE TABLE IF NOT EXISTS Usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome_completo VARCHAR(255) NOT NULL,
    cpf_cnpj VARCHAR(14) UNIQUE NOT NULL,
    email VARCHAR(255) UNIQUE NOT NULL,
    senha VARCHAR(255) NOT NULL,
    tipo_usuario VARCHAR(10) NOT NULL,
    saldo DECIMAL(10,2) DEFAULT 0.00,
    CHECK (tipo_usuario IN ('comum', 'lojista'))
);

-- Tabela de Transações
CREATE TABLE IF NOT EXISTS Transacoes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    remetente_id INT,
    destinatario_id INT,
    valor DECIMAL(10,2) NOT NULL,
    data_transacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (remetente_id) REFERENCES Usuarios(id),
    FOREIGN KEY (destinatario_id) REFERENCES Usuarios(id),
    CHECK (remetente_id <> destinatario_id)
);

select * from bankingapp.usuarios;
