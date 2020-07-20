# frozen_string_literal: true

# Copyright 2020, John Gaskin <brotherbain@gmail.com>
#
# This file is part of LionEditor.
#
# LionEditor is free software: you can redistribute it and/or modify
# it under the terms of the GNU General Public License as published by
# the Free Software Foundation, either version 3 of the License, or
# (at your option) any later version.
#
# LionEditor is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# GNU General Public License for more details.
#
# You should have received a copy of the GNU General Public License
# along with LionEditor.  If not, see <http://www.gnu.org/licenses/>.
require 'spec_helper'
require_relative '../../data_types/sprite_set'

RSpec.describe SpriteSet do
  include Datatypes
  it('loads all sprites') do
    # TODO: figure out how to test for something that is a hash/not nil, and have a certain number of
    # entries, first, last, etc.
    sprites = SpriteSet.all

    expect(sprites).to be_a(Hash)
    expect(sprites.count).to be(95)

    first_sprite = sprites['00']
    expect(first_sprite).to be_a(OpenStruct)
    expect(first_sprite.sprite).to eq('None')

    last_sprite = sprites['A3']
    expect(last_sprite.sprite).to eq('Luso')
  end
end
