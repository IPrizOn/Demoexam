CREATE TABLE product_type (
    id SERIAL PRIMARY KEY,
    type VARCHAR(50) NOT NULL,
    type_coefficient NUMERIC NOT NULL
);

CREATE TABLE material_type (
    id SERIAL PRIMARY KEY,
    type VARCHAR(50) NOT NULL,
    defect_rate NUMERIC NOT NULL
);

CREATE TABLE product (
    id SERIAL PRIMARY KEY,
    type_id INTEGER NOT NULL,
    material VARCHAR(50) NOT NULL,
    scheme VARCHAR(50) NOT NULL,
    class VARCHAR(50) NOT NULL,
    thickness_mm INTEGER NOT NULL,
    chamfered BOOLEAN NOT NULL,
    article VARCHAR(50) NOT NULL,
    min_cost NUMERIC NOT NULL,
    FOREIGN KEY (type_id) REFERENCES product_type(id)
);

CREATE TABLE partner (
    id SERIAL PRIMARY KEY,
    type VARCHAR(50) NOT NULL,
    name VARCHAR(100) NOT NULL,
    director_f VARCHAR(50) NOT NULL,
    director_i VARCHAR(50) NOT NULL,
    director_o VARCHAR(50) NOT NULL,
    email VARCHAR(255) NOT NULL,
    phone VARCHAR(25) NOT NULL,
    postcode VARCHAR(10) NOT NULL,
    address VARCHAR(255) NOT NULL,
    inn VARCHAR(25) NOT NULL,
    rating INTEGER NOT NULL
);

CREATE TABLE partner_product (
    id SERIAL PRIMARY KEY,
    product_id INTEGER NOT NULL,
    partner_id INTEGER NOT NULL,
    count INTEGER NOT NULL,
    sale_at DATE NOT NULL,
    FOREIGN KEY (product_id) REFERENCES product(id),
    FOREIGN KEY (partner_id) REFERENCES partner(id)
);