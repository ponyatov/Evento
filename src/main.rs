mod config;

fn main() {
    println!(
        "Hello, world! @ http://{ip}:{port}",
        ip = config::IP,
        port = config::PORT
    );
}
