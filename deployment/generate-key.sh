#!/bin/sh
set -e
SCRIPT_DIR="$( cd -- "$( dirname -- "${BASH_SOURCE[0]}" )" &> /dev/null && pwd )"
cd "$SCRIPT_DIR"

export $(grep -v '^#' .env | xargs) # Import variables from .env

docker run --rm -v $SCRIPT_DIR/container-volumes/fullnode/:/keygen/node radixdlt/keygen:1.0.0 --keystore=/keygen/node/keystore.ks --password="$FULLNODE_KEY_PASSWORD" --keypair-name=node
