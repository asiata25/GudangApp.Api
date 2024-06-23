-- membuat tabel gudang
create table gudang (
	kode uuid primary key default gen_random_uuid(),
	nama varchar(100) not null
)

-- membuat tabel barang
create table barang (
	kode uuid primary key default gen_random_uuid(),
	nama varchar(100) not null,
	harga integer not null,
	jumlah integer default 1,
	expired timestamp not null,
	kode_gudang uuid
)

-- menambahkan foreign key pada colum barang.kode_gudang dengan gudang.kode
alter table barang add constraint fk_barang_kode_gudang foreign key (kode_gudang) references gudang(kode)

-- menambahkan index pada expired dan kode_gudang pada tabel barang
create index idx_expired on
barang(expired)
create index idx_kode_gudang on
barang(kode_gudang)

-- menambahkan beberapa value ke tabel gudang
insert
	into
	gudang (nama)
values
('surabaya'),
('jakarta'),
('bandung')

-- menambahkan beberapa value ke tabel barang
insert
	into
	barang (nama,
	harga,
	jumlah,
	expired,
	kode_gudang)
values
('susu',12000,50,'2025-01-01','76f7d894-ba83-4df3-a0c5-b1cfce491d71'),
('roti',5000,30,'2024-11-30','0eb1c168-af25-419b-b755-6f13efb17e75'),
('kopi',15000,20,'2023-12-31','48133112-962b-47d6-8999-d00348f8e9f2'),
('Biskuit',8000,40,'2024-09-15','76f7d894-ba83-4df3-a0c5-b1cfce491d71'),
('sikat gigi',3000,100,'2023-08-31','0eb1c168-af25-419b-b755-6f13efb17e75'),
('sabun mandi',7000,60,'2025-02-28','48133112-962b-47d6-8999-d00348f8e9f2'),
('shampoo',10000,25,'2024-07-15','76f7d894-ba83-4df3-a0c5-b1cfce491d71'),
('pasta gigi',4000,80,'2023-10-31','0eb1c168-af25-419b-b755-6f13efb17e75'),
('teh',8000,35,'2025-03-31','48133112-962b-47d6-8999-d00348f8e9f2'),
('minyak goreng',15000,15,'2024-06-30','76f7d894-ba83-4df3-a0c5-b1cfce491d71');


-- membuat function (store procedure) list barang
create or replace
function daftar_barang(
    query varchar(100),
    page integer,
    size integer
)
returns table (
    kode_gudang uuid,
    nama_gudang varchar(100),
    kode_barang uuid,
    nama_barang varchar(100),
    harga_barang integer,
    jumlah_barang integer,
    expired_barang timestamp
)
as $$
begin
    return query execute
    'select
	g.kode ,
	g.nama ,
	b.kode ,
	b.nama ,
	b.harga ,
	b.jumlah ,
	b.expired
	from
		barang b
	left join gudang g on
		g.kode = b.kode_gudang
	where
		b.nama like ''%' || query || '%''
	order by
		b.kode
	limit ' || size || ' offset ' || (page - 1) * size;
end;
$$ language plpgsql;

select * from daftar_barang('', 1, 10)

-- membuat trigger
create or replace function  peringatan_kadaluarsa()
returns trigger  
as $$
declare 
	exp record;
begin
    raise notice 'ada barang yang expired di gudang %:', new.kode_gudang;
    for exp in select * from barang where expired < current_date  loop
        raise notice 'Expired item: %', exp.nama;
    end loop;
    return new;
end;
$$ language plpgsql;
create trigger trigger_barang_expired
after insert on barang for each row execute function peringatan_kadaluarsa()

insert
	into
	gudang (nama)
values
('malang')

insert
	into
	barang (nama,
	harga,
	jumlah,
	expired,
	kode_gudang)
values
('kecap',8500,25,'2023-01-01','bb08f09b-7ede-454b-bb2f-ea95c12eebf6')
