FROM nginx:latest

# SSL sertifikası için dizin oluştur
RUN mkdir -p /etc/nginx/ssl

# OpenSSL ile self-signed sertifika oluştur
RUN apt-get update && apt-get install -y openssl && \
    openssl req -x509 -newkey rsa:4096 -keyout /etc/nginx/ssl/nginx-selfsigned.key \
    -out /etc/nginx/ssl/nginx-selfsigned.crt -days 365 -nodes -subj "/CN=iso.com.az"

# Nginx konfigürasyon dosyasını kopyala
COPY nginx.conf /etc/nginx/nginx.conf
