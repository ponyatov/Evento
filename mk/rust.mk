RTARGET = x86_64-unknown-linux-gnu
# RTARGET = thumbv7m-none-eabi
# RTARGET = thumbv7em-none-eabihf
# RTARGET = aarch64-unknown-linux-gnu
# RTARGET = i686-pc-windows-gnu
# RTARGET = wasm32-unknown-unknown

$(RUSTUP) $(CARGO):
	curl --proto '=https' --tlsv1.2 -sSf https://sh.rustup.rs | sh
	rustup target add x86_64-unknown-linux-gnu
# rustup target add thumbv7m-none-eabi
# rustup target add thumbv7em-none-eabihf
# rustup target add aarch64-unknown-linux-gnu
# rustup target add i686-pc-windows-gnu
# rustup target add wasm32-unknown-unknown
	rustup component add rust-analyzer rustfmt rust-src
# rustup component add llvm-tools
	cargo install cargo-watch cargo-binutils
