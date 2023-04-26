CREATE TABLE users (
    id INT PRIMARY KEY IDENTITY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    firstname VARCHAR(50) NOT NULL,
    lastname VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    phone VARCHAR(20) NOT NULL UNIQUE
);

CREATE TABLE products (
    id INT PRIMARY KEY IDENTITY,
    name VARCHAR(100) NOT NULL,
    description TEXT,
    price DECIMAL(10, 2) NOT NULL,
    category VARCHAR(50) NOT NULL,
    stock INT NOT NULL CHECK (stock >= 0),
    image_url VARCHAR(200)
);

CREATE TABLE carts (
    id INT PRIMARY KEY IDENTITY,
    user_id INT NOT NULL REFERENCES users(id),
    created_at DATETIME DEFAULT GETDATE()
);

CREATE TABLE cart_items (
    id INT PRIMARY KEY IDENTITY,
    cart_id INT NOT NULL REFERENCES carts(id),
    product_id INT NOT NULL REFERENCES products(id),
    quantity INT NOT NULL CHECK (quantity > 0)
);

CREATE TABLE orders (
    id INT PRIMARY KEY IDENTITY,
    user_id INT NOT NULL REFERENCES users(id),
    created_at DATETIME DEFAULT GETDATE(),
    status VARCHAR(20) NOT NULL CHECK (status IN ('cancelled', 'processing', 'completed')),
    delivery_method VARCHAR(50) NOT NULL
);

CREATE TABLE order_items (
    id INT PRIMARY KEY IDENTITY,
    order_id INT NOT NULL REFERENCES orders(id),
    product_id INT NOT NULL REFERENCES products(id),
    quantity INT NOT NULL CHECK (quantity > 0),
    price DECIMAL(10, 2) NOT NULL
);